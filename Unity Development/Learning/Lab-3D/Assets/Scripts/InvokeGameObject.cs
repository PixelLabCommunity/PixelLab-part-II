using UnityEngine;

public class InvokeGameObject : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private Vector3 spawnPlace;
    private readonly float _spawnTime = 2.0f;

    private void Start()
    {
        Invoke(nameof(SummonGameObject), _spawnTime);
    }

    private void SummonGameObject()
    {
        Instantiate(spawnObject, spawnPlace, Quaternion.identity);
    }
}