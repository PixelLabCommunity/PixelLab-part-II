using UnityEngine;

public class CameraMainController : MonoBehaviour
{
    [SerializeField] private GameObject playerPosition;
    private Vector3 _offsetPosition;

    private void Start()
    {
        _offsetPosition = transform.position - playerPosition.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = playerPosition.transform.position + _offsetPosition;
    }
}