using Platformer.Gameplay;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class EmitParticlesOnLand : MonoBehaviour
{
    [SerializeField] private bool emitOnLand = true;
    [SerializeField] private bool emitOnEnemyDeath = true;

#if UNITY_TEMPLATE_PLATFORMER

    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();

        if (emitOnLand)
        {
            PlayerLanded.OnExecute += PlayerLandedOnExecute;

            void PlayerLandedOnExecute(PlayerLanded obj)
            {
                _particleSystem.Play();
            }
        }

        if (!emitOnEnemyDeath) return;
        {
            EnemyDeath.OnExecute += EnemyDeathOnExecute;

            void EnemyDeathOnExecute(EnemyDeath obj)
            {
                _particleSystem.Play();
            }
        }
    }

#endif
}