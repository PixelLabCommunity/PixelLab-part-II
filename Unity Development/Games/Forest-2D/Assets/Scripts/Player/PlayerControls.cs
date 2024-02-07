using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private const float MinMovingSpeed = 0.1f;
    [SerializeField] private float speed = 5.0f;
    private bool _isRunning;
    private Rigidbody2D _rigidbody2D;
    public static PlayerControls template { get; private set; }

    private void Awake()
    {
        template = this;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        var playerPosition = GameInput.template.GetVectorMovement();
        
        _rigidbody2D.MovePosition(_rigidbody2D.position + playerPosition * (speed * Time.fixedDeltaTime));
        if (Mathf.Abs(playerPosition.x) > MinMovingSpeed || Mathf.Abs(playerPosition.y) > MinMovingSpeed)
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