using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rigidbody2d;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.magnitude > 1000.0f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var enemy = other.collider.GetComponent<Enemy>();

        if (enemy != null) enemy.Fix();

        Destroy(gameObject);
    }

    public void Launch(Vector2 direction, float force)
    {
        _rigidbody2d.AddForce(direction * force);
    }
}