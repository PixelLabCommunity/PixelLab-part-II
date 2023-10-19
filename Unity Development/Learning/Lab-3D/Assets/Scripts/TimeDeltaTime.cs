using UnityEngine;

public class TimeDeltaTime : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float countdown = 3f;
    private readonly float _zeroValue = 0f;

    private void Update()
    {
        CountdownLight();
    }

    private void CountdownLight()
    {
        countdown -= Time.deltaTime;
        if (countdown <= _zeroValue) GetComponent<Light>().enabled = true;
    }
}