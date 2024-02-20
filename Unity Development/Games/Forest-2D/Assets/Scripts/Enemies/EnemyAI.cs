using System;
using Forest2D.Utils;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    private const float BaseTime = 0f;
    [SerializeField] private State startingState;
    [SerializeField] private float wanderDistanceMax = 7f;
    [SerializeField] private float wanderDistanceMin = 3f;
    [SerializeField] private float wanderTimerMax = 2f;
    [SerializeField] private bool isChasingEnemy;
    [SerializeField] private bool isAttackingEnemy;
    private readonly float _attackingDistance = 2f;

    private readonly Vector3 _changeRotation = new(0, -180, 0);
    private readonly float _chasingDistance = 4f;
    private readonly float _chasingSpeedMultiplayer = 2f;
    private readonly Vector3 _stateRotation = new(0, 0, 0);
    private float _attackRate = 2f;
    private float _chasingSpeed;
    private State _currentSate;
    private float _currentTime;


    private NavMeshAgent _navMeshAgent;
    private float _nextAttackTime;
    private Vector3 _startingPosition;
    private float _walkingSpeed;
    private float _walkingTime;
    private Vector3 _wanderPosition;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        StartState();
    }

    private void Update()
    {
        AiState();
    }


    public event EventHandler OnEnemyAttack;


    private void AiState()
    {
        switch (_currentSate)
        {
            case State.Wandering:
                _currentTime -= Time.deltaTime;
                if (_currentTime < BaseTime)
                {
                    Wandering();
                    _currentTime = wanderTimerMax;
                }

                CheckCurrentState();

                break;
            case State.Attacking:
                AttackingTarget();
                CheckCurrentState();
                break;
            case State.Chasing:
                ChasingTarget();
                CheckCurrentState();
                break;
            case State.Death:
                break;
            default:
            case State.Idle:
                break;
        }
    }

    private void Wandering()
    {
        _startingPosition = transform.position;
        _wanderPosition = GetWanderPosition();
        ChangeFacingDirection(_startingPosition, _wanderPosition);
        _navMeshAgent.SetDestination(_wanderPosition);
    }

    private void AttackingTarget()
    {
        if (Time.time > _nextAttackTime)
        {
            OnEnemyAttack?.Invoke(this, EventArgs.Empty);
            _nextAttackTime = Time.time + _attackRate;
        }
        
    }

    public bool IsRunning()
    {
        return _navMeshAgent.velocity != Vector3.zero;
    }


    private void ChasingTarget()
    {
        _navMeshAgent.SetDestination(PlayerControls.template.transform.position);
    }

    private void CheckCurrentState()
    {
        var distanceToPlayer = Vector3.Distance(transform.position, PlayerControls.template.transform.position);
        var newState = State.Wandering;
        if (isChasingEnemy)
            if (distanceToPlayer <= _chasingDistance)
                newState = State.Chasing;

        if (isAttackingEnemy)
            if (distanceToPlayer <= _attackingDistance)
                newState = State.Attacking;

        if (newState == _currentSate) return;
        switch (newState)
        {
            case State.Chasing:
                _navMeshAgent.ResetPath();
                _navMeshAgent.speed = _chasingSpeed;
                break;
            case State.Wandering:
                _walkingTime = 0f;
                _navMeshAgent.speed = _walkingSpeed;
                break;
            case State.Attacking:
                _navMeshAgent.ResetPath();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }


        _currentSate = newState;
    }

    private Vector2 GetWanderPosition()
    {
        return _startingPosition + ForestUtils.GetRandomDir() * Random.Range(wanderDistanceMin, wanderDistanceMax);
    }

    private void StartState()
    {
        _currentSate = startingState;
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        var speed = _navMeshAgent.speed;
        _walkingSpeed = speed;
        _chasingSpeed = speed * _chasingSpeedMultiplayer;
    }

    private void ChangeFacingDirection(Vector2 sourcePosition, Vector2 targetPosition)
    {
        transform.rotation = sourcePosition.x > targetPosition.x
            ? Quaternion.Euler(_changeRotation)
            : Quaternion.Euler(_stateRotation);
    }

    private enum State
    {
        Idle,
        Chasing,
        Attacking,
        Death,
        Wandering
    }
}