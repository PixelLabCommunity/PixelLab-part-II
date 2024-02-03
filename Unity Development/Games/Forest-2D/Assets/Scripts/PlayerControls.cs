using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    } // ReSharper disable Unity.PerformanceAnalysis
    private void PlayerMovement()
    {
        var playerPosition = GameInput.instance.GetVectorMovement();
        playerPosition = playerPosition.normalized;

        _rigidbody2D.MovePosition(_rigidbody2D.position + playerPosition * (speed * Time.fixedDeltaTime));
    }
}