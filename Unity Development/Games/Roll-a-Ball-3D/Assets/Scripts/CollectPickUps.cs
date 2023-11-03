using UnityEngine;

public class CollectPickUps : MonoBehaviour
{
    [SerializeField] private ParticleSystem activeParticle;
    [SerializeField] private AudioSource activeSound;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("PickUp")) return;
        if (activeParticle != null && activeSound != null)
        {
            activeParticle.gameObject.SetActive(true);
            activeSound.gameObject.SetActive(true);
            var position = other.transform.position;
            activeParticle.transform.position = position;
            activeSound.transform.position = position;
            activeParticle.Play();
            activeSound.Play();
        }

        Destroy(other.gameObject);
        other.gameObject.SetActive(false);
    }
}