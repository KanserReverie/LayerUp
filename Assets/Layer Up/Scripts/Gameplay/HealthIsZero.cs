using Layer_Up.Scripts.Core;
using Layer_Up.Scripts.Mechanics;
using static Layer_Up.Scripts.Core.Simulation;

namespace Layer_Up.Scripts.Gameplay
{
    /// <summary>
    /// Fired when the player health reaches 0. This usually would result in a 
    /// PlayerDeath event.
    /// </summary>
    /// <typeparam name="HealthIsZero"></typeparam>
    public class HealthIsZero : Simulation.Event<HealthIsZero>
    {
        public Health health;

        public override void Execute()
        {
            Schedule<PlayerDeath>();
        }
    }
}