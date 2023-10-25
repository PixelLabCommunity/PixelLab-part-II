using UnityEngine;

public class LogErrors : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Test Simple Log!");
        Debug.LogWarning("Warning Here!");
        Debug.LogError("Very Dangerous Here!");
    }
}