using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private const float MinMovingSpeed = 0.1f;
    [SerializeField] private float speed = 5.0f;
    private bool _isRunning;
    private Vector2 _playerPosition;
    private Rigidbody2D _rigidbody2D;
    public static PlayerControls template { get; private set; }

    private void Awake()
    {
        template = this;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameInput.template.OnPlayerAttack += GameInput_OnPlayerAttack;
    }

    private void Update()
    {
        _playerPosition = GameInput.template.GetVectorMovement();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private static void GameInput_OnPlayerAttack(object sender, EventArgs e)
    {
        ActiveWeapon.template.GetActiveWeapon().Attack();
    }

    private void PlayerMovement()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _playerPosition * (speed * Time.fixedDeltaTime));
        if (Mathf.Abs(_playerPosition.x) > MinMovingSpeed || Mathf.Abs(_playerPosition.y) > MinMovingSpeed)
            _isRunning = true;

        else
            _isRunning = false;
    }

    protected internal bool IsRuning()
    {
        return _isRunning;
    }

    public Vector2 GetPlayerScreenPosition()
    {
        Vector2 playerScreenPosition = Camera.main!.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
}