using UnityEngine;

public class SkeletonVisual : MonoBehaviour
{
    private const string IS_RUNNING = "IsRunning";
    private const string CHASING_SPEED_MULTIPLIER = "ChasingSpeedMultiplier";
    [SerializeField] private EnemyAI enemyAI;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(IS_RUNNING, enemyAI.IsRunning());
        _animator.SetFloat(CHASING_SPEED_MULTIPLIER, enemyAI.GetWalkingAnimationSpeed());
    }
}