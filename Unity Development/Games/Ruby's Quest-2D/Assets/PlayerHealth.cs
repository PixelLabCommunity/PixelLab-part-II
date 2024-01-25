using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private const int MinHealth = 0;
    private const int HealthUp = 1;
    [SerializeField] private int maxHealth = 5;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("HealthUp")) return;
        ChangeHealth(HealthUp);
        Destroy(other.gameObject);
    }

    private void ChangeHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, MinHealth, maxHealth);
        Debug.Log(_currentHealth + "/" + maxHealth);
    }
}