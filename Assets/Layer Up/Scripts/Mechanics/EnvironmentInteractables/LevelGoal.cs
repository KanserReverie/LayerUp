using Layer_Up.Scripts.Gameplay;
using static Layer_Up.Scripts.Core.Simulation;
using UnityEngine;
namespace Layer_Up.Scripts.Mechanics.EnvironmentInteractables
{
    public class LevelGoal: MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            PlayerController playerController = collider.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                var ev = Schedule<PlayerEnteredLevelGoal>();
                ev.levelGoal = this;
            }
        }
    }
}
