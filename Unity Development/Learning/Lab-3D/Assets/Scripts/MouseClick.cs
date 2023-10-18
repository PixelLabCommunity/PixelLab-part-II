using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 500f;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        _rigidbody.AddForce(transform.forward * moveSpeed);
        _rigidbody.useGravity = true;
    }
}