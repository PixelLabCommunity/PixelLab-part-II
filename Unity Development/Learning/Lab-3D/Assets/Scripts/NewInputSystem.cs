using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystem : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue inputValue)
    {
        _rigidbody.velocity = inputValue.Get<Vector3>() * speed;
    }
}