using UnityEngine;

public class PickUpScore : MonoBehaviour
{
    private int _countScore;

    private void Start()
    {
        Debug.LogWarning($"Score is : {_countScore}");
    }

    private void FixedUpdate()
    {
        Debug.LogWarning($"{_countScore}");
        if (_countScore == 12) Debug.LogWarning("YOU WON!!!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) _countScore++;
    }
}