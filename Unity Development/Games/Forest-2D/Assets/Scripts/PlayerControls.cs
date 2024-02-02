using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        var playerPosition = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) playerPosition.y = 1.0f;

        if (Input.GetKey(KeyCode.A)) playerPosition.x = -1.0f;

        if (Input.GetKey(KeyCode.S)) playerPosition.y = -1.0f;

        if (Input.GetKey(KeyCode.D)) playerPosition.x = 1.0f;

        _rigidbody2D.MovePosition(_rigidbody2D.position + playerPosition);
    }
}