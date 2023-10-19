using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    [SerializeField] private float destroyTimer = 3f;


    private void Update()
    {
        Destroy(gameObject, destroyTimer);
    }
}