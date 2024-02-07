using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class PlayerVisual : MonoBehaviour
{
    private const string IS_RUNNING = "IsRunning";

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    [SuppressMessage("ReSharper", "Unity.PreferAddressByIdToGraphicsParams")]
    private void Update()
    {
        _animator.SetBool(IS_RUNNING, PlayerControls.template.IsRuning());
        PlayerSpriteFlip();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void PlayerSpriteFlip()
    {
        var mousePosition = GameInput.GetMousePosition();
        var playerScreenPosition = PlayerControls.template.GetPlayerScreenPosition();

        _spriteRenderer.flipX = mousePosition.x < playerScreenPosition.x;
    }
}