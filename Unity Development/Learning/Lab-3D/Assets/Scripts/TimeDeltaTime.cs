using UnityEngine;

public class TimeDeltaTime : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float countdown = 3f;
    private readonly float _zeroValue = 0f;

    private void FixedUpdate()
    {
        CountdownLight();
        SmoothMovement();
    }

    private void CountdownLight()
    {
        countdown -= Time.deltaTime;
        if (countdown <= _zeroValue) GetComponent<Light>().enabled = true;
    }

    private void SmoothMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            transform.position += new Vector3(speed * Time.deltaTime, _zeroValue, _zeroValue);
    }
}