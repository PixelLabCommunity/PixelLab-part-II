using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystem : MonoBehaviour
{
    [SerializeField] private InputAction playerControls;
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float jumpForce = 15.0f;
    private readonly float _basePositionY = 0.0f;
    private Rigidbody _rigidbody;
    private Vector3 _spawnPosition = Vector3.zero;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _spawnPosition = playerControls.ReadValue<Vector3>();
        JumpButton();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_spawnPosition.x * movementSpeed, _basePositionY,
            _spawnPosition.z * movementSpeed);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void JumpButton()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }
}