using UnityEngine;
using UnityEngine.Events;

public class SimpleTrigger : MonoBehaviour
{
    [SerializeField] private Rigidbody2D triggerBody;
    [SerializeField] private UnityEvent onTriggerEnter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggerBody == null) return;
        var hitRb = other.attachedRigidbody;
        if (hitRb == triggerBody) onTriggerEnter.Invoke();
    }
}