using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static readonly int Property = Animator.StringToHash("Look X");
    private static readonly int Property1 = Animator.StringToHash("Look Y");
    private static readonly int Speed = Animator.StringToHash("Speed");
    [SerializeField] private float speed = 5.0f;
    private Animator _animator;
    private Vector2 _lookDirection = new(1, 0);

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue inputValue)
    {
        var move = inputValue.Get<Vector2>();
        _rigidbody2D.velocity = move * speed;

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            _lookDirection.Set(move.x, move.y);
            _lookDirection.Normalize();
        }

        _animator.SetFloat(Property, _lookDirection.x);
        _animator.SetFloat(Property1, _lookDirection.y);
        _animator.SetFloat(Speed, move.magnitude);
    }
}