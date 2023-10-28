using UnityEngine;

public class RotatePickUp : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private Vector3 position = new(45f, 55f, 65f);

    private void Update()
    {
        transform.Rotate(position * (Time.deltaTime * rotationSpeed));
    }
}