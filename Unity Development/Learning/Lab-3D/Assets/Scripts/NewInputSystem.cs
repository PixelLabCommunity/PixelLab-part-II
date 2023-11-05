using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystem : MonoBehaviour
{
    [SerializeField] private InputAction playerControls;
    [SerializeField] private float movementSpeed = 10.0f;
    private readonly float _basePositionY = 0.0f;
    private Rigidbody _rigidbody;
    private Vector3 _spawnPostion = Vector3.zero;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _spawnPostion = playerControls.ReadValue<Vector3>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_spawnPostion.x * movementSpeed, _basePositionY,
            _spawnPostion.z * movementSpeed);
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