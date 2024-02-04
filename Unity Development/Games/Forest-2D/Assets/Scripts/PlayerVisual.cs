using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private const string IsRunning = "IsRunning";
    private static readonly int Running = Animator.StringToHash(IsRunning);

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_animator) _animator.SetBool(Running, PlayerControls.template.IsRuning());
    }
}