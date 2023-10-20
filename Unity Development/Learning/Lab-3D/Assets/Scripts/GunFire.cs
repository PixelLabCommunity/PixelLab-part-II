using UnityEngine;

public class GunFire : MonoBehaviour
{
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private float forceSpeedValue = 1000f;

    private void Update()
    {
        FireInputButton();
    }

    private void FireInputButton()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bulletForce = Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
            bulletForce.AddForce(bulletPosition.up * forceSpeedValue);
        }
    }
}