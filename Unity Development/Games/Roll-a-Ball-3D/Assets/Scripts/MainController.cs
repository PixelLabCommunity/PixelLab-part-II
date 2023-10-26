using UnityEngine;
using UnityEngine.InputSystem;

public class MainController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10;
    private readonly float _movementBase = 0.0f;
    private float _movementVectorX;
    private float _movementVectorY;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var movement = new Vector3(_movementVectorX, _movementBase, _movementVectorY);
        _rigidbody.AddForce(movement * movementSpeed);
    }

    private void OnMove(InputValue movementValue)
    {
        var movementVector = movementValue.Get<Vector2>();
        _movementVectorX = movementVector.x;
        _movementVectorY = movementVector.y;
    }
}