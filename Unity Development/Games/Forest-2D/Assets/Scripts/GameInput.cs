using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    public static GameInput instance { get; private set; }

    private void Awake()
    {
        instance = this;
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
    }

    protected internal Vector2 GetVectorMovement()
    {
        var inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
}