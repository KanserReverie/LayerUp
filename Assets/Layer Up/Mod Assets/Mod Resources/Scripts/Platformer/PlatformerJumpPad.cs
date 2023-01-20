using Layer_Up.Scripts.Mechanics;
using UnityEngine;

namespace Layer_Up.Mod_Assets.Mod_Resources.Scripts.Platformer
{
    public class PlatformerJumpPad : MonoBehaviour
    {
        public float verticalVelocity;

        void OnTriggerEnter2D(Collider2D other)
        {
            var rb = other.attachedRigidbody;
            if (rb == null) return;
            var player = rb.GetComponent<PlayerController>();
            if (player == null) return;
            AddVelocity(player);
        }

        void AddVelocity(PlayerController player)
        {
            player.velocity.y = verticalVelocity;
        }
    }
}
