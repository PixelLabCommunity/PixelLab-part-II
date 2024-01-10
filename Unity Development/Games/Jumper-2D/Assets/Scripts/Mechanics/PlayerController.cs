using System;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool _stopJump;
        /*internal new*/ public Collider2D collider2d;
        /*internal new*/ public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        private bool _jump;
        private Vector2 _move;
        private SpriteRenderer _spriteRenderer;
        internal Animator Animator;
        private readonly PlatformerModel _model = Simulation.GetModel<PlatformerModel>();
        private static readonly int Grounded = Animator.StringToHash("grounded");
        private static readonly int VelocityX = Animator.StringToHash("velocityX");

        public Bounds Bounds => collider2d.bounds;

        private void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            Animator = GetComponent<Animator>();
        }

        protected override void Update()
        {
            if (controlEnabled)
            {
                _move.x = Input.GetAxis("Horizontal");
                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                    jumpState = JumpState.PrepareToJump;
                else if (Input.GetButtonUp("Jump"))
                {
                    _stopJump = true;
                    Schedule<PlayerStopJump>().player = this;
                }
            }
            else
            {
                _move.x = 0;
            }
            UpdateJumpState();
            base.Update();
        }

        private void UpdateJumpState()
        {
            _jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    _jump = true;
                    _stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
                case JumpState.Grounded:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override void ComputeVelocity()
        {
            if (_jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * _model.jumpModifier;
                _jump = false;
            }
            else if (_stopJump)
            {
                _stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * _model.jumpDeceleration;
                }
            }

            _spriteRenderer.flipX = _move.x switch
            {
                > 0.01f => false,
                < -0.01f => true,
                _ => _spriteRenderer.flipX
            };

            Animator.SetBool(Grounded, IsGrounded);
            Animator.SetFloat(VelocityX, Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = _move * maxSpeed;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}