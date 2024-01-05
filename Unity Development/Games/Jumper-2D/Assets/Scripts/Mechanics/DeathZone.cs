using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// DeathZone components mark a collider which will schedule a
    /// PlayerEnteredDeathZone event when the player enters the trigger.
    /// </summary>
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var playerController  = collider2D.gameObject.GetComponent<PlayerController>();
            if (playerController == null) return;
            var ev = Schedule<PlayerEnteredDeathZone>();
            ev.deathzone = this;
        }
    }
}