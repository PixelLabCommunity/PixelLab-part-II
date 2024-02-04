using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class PlayerVisual : MonoBehaviour
{
    private const string IS_RUNNING = "IsRunning";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [SuppressMessage("ReSharper", "Unity.PreferAddressByIdToGraphicsParams")]
    private void Update()
    {
        _animator.SetBool(IS_RUNNING, PlayerControls.template.IsRuning());
    }
}