using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private Sword sword;
    public static ActiveWeapon template { get; private set; }

    private void Awake()
    {
        template = this;
    }

    private void Update()
    {
        WeaponSpriteFlip();
    }

    public Sword GetActiveWeapon()
    {
        return sword;
    }

    private void WeaponSpriteFlip()
    {
        var mousePosition = GameInput.GetMousePosition();
        var playerScreenPosition = PlayerControls.template.GetPlayerScreenPosition();

        transform.rotation = Quaternion.Euler(0, mousePosition.x < playerScreenPosition.x ? 180 : 0, 0);
    }
}