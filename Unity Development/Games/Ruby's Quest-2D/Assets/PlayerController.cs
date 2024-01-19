using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private PlayerControls _playerControls;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue inputValue)
    {
        _rigidbody2D.velocity = inputValue.Get<Vector2>() * speed;
    }
}