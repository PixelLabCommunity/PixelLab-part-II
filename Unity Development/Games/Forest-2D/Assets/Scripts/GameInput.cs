using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    public static GameInput template { get; private set; }


    private void Awake()
    {
        template = this;
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
        _playerInputActions.Combat.Attack.started += PlayerAttack_started;
    }

    public event EventHandler OnPlayerAttack;

    private void PlayerAttack_started(InputAction.CallbackContext obj)
    {
        OnPlayerAttack!.Invoke(this, EventArgs.Empty);
    }

    protected internal Vector2 GetVectorMovement()
    {
        var inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }

    public static Vector2 GetMousePosition()
    {
        var mousePosition = Mouse.current.position.ReadValue();
        return mousePosition;
    }
}