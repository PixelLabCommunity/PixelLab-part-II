using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var controller = other.GetComponent<PlayerHealth>();

        if (controller != null) controller.ChangeHealth(1);
        //Debug.Log("Your health increased to 1 !");
    }
}