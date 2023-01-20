using System.Collections;
using Layer_Up.Scripts.Mechanics;
using UnityEngine;

namespace Layer_Up.Mod_Assets.Mod_Resources.Scripts.Platformer
{
    public class PlatformerSpeedPad : MonoBehaviour
    {
        public float maxSpeed;

        [Range (0, 5)]
        public float duration = 1f;

        void OnTriggerEnter2D(Collider2D other){
            var rb = other.attachedRigidbody;
            if (rb == null) return;
            var player = rb.GetComponent<PlayerController>();
            if (player == null) return;
            player.StartCoroutine(PlayerModifier(player, duration));
        }

        IEnumerator PlayerModifier(PlayerController player, float lifetime){
            var initialSpeed = player.maxSpeed;
            player.maxSpeed = maxSpeed;
            yield return new WaitForSeconds(lifetime);
            player.maxSpeed = initialSpeed;
        }

    }
}
