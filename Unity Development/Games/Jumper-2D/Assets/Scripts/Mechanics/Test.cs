using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enterBody;
    [SerializeField] private UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (enterBody == null) return;

        var otherAttachedRigidbody = other.attachedRigidbody;
        if (otherAttachedRigidbody == enterBody) onTriggerEnter.Invoke();
    }
}