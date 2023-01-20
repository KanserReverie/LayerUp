using Layer_Up.Scripts.Core;
using Layer_Up.Scripts.Mechanics;
namespace Layer_Up.Scripts.Gameplay
{
    /// <summary>
    /// Fired when the player character lands after being airborne.
    /// </summary>
    /// <typeparam name="PlayerLanded"></typeparam>
    public class PlayerLanded : Simulation.Event<PlayerLanded>
    {
        public PlayerController player;

        public override void Execute()
        {

        }
    }
}