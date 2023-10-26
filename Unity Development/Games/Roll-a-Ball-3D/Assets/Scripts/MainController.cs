using UnityEngine;
using UnityEngine.InputSystem;

public class MainController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10;
    private Rigidbody _rigidbody;
    private float _movementVectorX;
    private float _movementVectorY;
    private readonly float _movementBase = 0.0f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_movementVectorX, _movementBase, _movementVectorY);
        _rigidbody.AddForce(movement*movementSpeed);
    }
    
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        _movementVectorX = movementVector.x;
        _movementVectorY = movementVector.y;
    }

   
}
