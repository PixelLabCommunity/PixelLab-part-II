using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystem : MonoBehaviour
{
    [SerializeField] private InputAction playerControls;
    [SerializeField] private float movementSpeed = 10f;
    private readonly float _baseSpawn = 0.0f;
    private Vector3 _moveDirections = Vector3.zero;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _moveDirections = playerControls.ReadValue<Vector3>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_moveDirections.x * movementSpeed, _baseSpawn,
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