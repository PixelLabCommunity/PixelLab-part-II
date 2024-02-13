using System;
using UnityEngine;

public class SwordVisual : MonoBehaviour
{
    private const string ATTACK = "Attack";
    [SerializeField] private Sword sword;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        sword.OnSwordSwing += Sword_OnSwordSwing;
    }

    private void Sword_OnSwordSwing(object sender, EventArgs e)
    {
        _animator.SetTrigger(ATTACK);
    }
}