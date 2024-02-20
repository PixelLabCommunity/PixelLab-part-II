using System;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    [SerializeField] private int maxHealth = 20;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public event EventHandler OnEnemyAttack;

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        DetectDeath();
    }

    public void DetectDeath()
    {
        if (_currentHealth > 0) return;
        Destroy(gameObject);
        Debug.LogWarning("Creature DEAD!");
    }
}