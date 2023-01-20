using Layer_Up.Scripts.Core;
using Layer_Up.Scripts.Mechanics.EnvironmentInteractables;
using Layer_Up.Scripts.Model;
namespace Layer_Up.Scripts.Gameplay
{
    /// <summary>
    /// Fired when a player enters a trigger with a Level Goal component.
    /// </summary>
    public class PlayerEnteredLevelGoal : Simulation.Event<PlayerEnteredLevelGoal>
    {
        public LevelGoal levelGoal;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            Simulation.Schedule<GotoNextLevel>(0);
        }
    }
}