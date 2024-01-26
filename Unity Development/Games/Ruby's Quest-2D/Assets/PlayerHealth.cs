using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private const int MinHealth = 0;
    private const int HealthUp = 1;
    private const int HealthDown = -1;
    [SerializeField] private int maxHealth = 5;
    private readonly float _timeInvisible = 2.0f;

    private int _currentHealth;
    private float _invisibleTimer;
    private bool _isInvisible;

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    private void Update()
    {
        if (!_isInvisible) return;
        _invisibleTimer -= Time.deltaTime;
        if (_invisibleTimer < 0) _isInvisible = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("HealthUp")) return;
        ChangeHealth(HealthUp);
        Destroy(other.gameObject);
        Debug.Log("Your Health increased to 1 HP! ");
        if (!other.CompareTag("HealthDown")) return;
        ChangeHealth(HealthDown);
        Debug.Log("Your Health decreased to -1 HP! ");
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (_isInvisible)
                return;

            _isInvisible = true;
            _invisibleTimer = _timeInvisible;
        }

        _currentHealth = Mathf.Clamp(_currentHealth + amount, MinHealth, maxHealth);
        Debug.Log(_currentHealth + "/" + maxHealth);
    }
}