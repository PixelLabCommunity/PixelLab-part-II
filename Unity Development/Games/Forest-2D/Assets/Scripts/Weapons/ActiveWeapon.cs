using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private Sword sword;
    public static ActiveWeapon template { get; private set; }

    private void Awake()
    {
        template = this;
    }

    public Sword GetActiveWeapon()
    {
        return sword;
    }
}