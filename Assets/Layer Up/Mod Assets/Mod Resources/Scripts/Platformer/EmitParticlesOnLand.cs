using Layer_Up.Scripts.Gameplay;
using UnityEngine;

namespace Layer_Up.Mod_Assets.Mod_Resources.Scripts.Platformer
{
    [RequireComponent(typeof(ParticleSystem))]
    public class EmitParticlesOnLand : MonoBehaviour
    {

        public bool emitOnLand = true;
        public bool emitOnEnemyDeath = true;

#if UNITY_TEMPLATE_PLATFORMER

        ParticleSystem p;

        void Start()
        {
            p = GetComponent<ParticleSystem>();

            if (emitOnLand) {
                PlayerLanded.OnExecute += PlayerLanded_OnExecute;
                void PlayerLanded_OnExecute(PlayerLanded obj) {
                    p.Play();
                }
            }

            if (emitOnEnemyDeath) {
                EnemyDeath.OnExecute += EnemyDeath_OnExecute;
                void EnemyDeath_OnExecute(EnemyDeath obj) {
                    p.Play();
                }
            }

        }

#endif

    }
}
