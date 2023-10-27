using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystemControls : MonoBehaviour
{
    [SerializeField] private InputAction playerControls;
    [SerializeField] private float movementSpeed = 10;
    private readonly float _movementBase = 0.0f;
    private Vector3 _moveDirections = Vector3.zero;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null) Debug.LogError("Rigidbody component not found on the GameObject.");
    }

    private void Update()
    {
        _moveDirections = playerControls.ReadValue<Vector3>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody != null)
            _rigidbody.velocity = new Vector3(_moveDirections.x * movementSpeed, _movementBase,
                _moveDirections.z * movementSpeed);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}