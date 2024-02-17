using System;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private int damageAmount = 2;
    private PolygonCollider2D _polygonCollider2D;

    private void Awake()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    private void Start()
    {
        AttackColliderOff();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out EnemyEntity enemyEntity)) enemyEntity.TakeDamade(damageAmount);
    }

    public event EventHandler OnSwordSwing;

    public void Attack()
    {
        AttackColliderCheck();
        OnSwordSwing!.Invoke(this, EventArgs.Empty);
    }

    private void AttackColliderOn()
    {
        _polygonCollider2D.enabled = true;
    }

    public void AttackColliderOff()
    {
        _polygonCollider2D.enabled = false;
    }

    private void AttackColliderCheck()
    {
        AttackColliderOff();
        AttackColliderOn();
    }
}