using Layer_Up.Scripts.Core;
using Layer_Up.Scripts.Model;
namespace Layer_Up.Scripts.Gameplay
{
    /// <summary>
    /// Fired when the player has completed level.
    /// </summary>
    public class GotoNextLevel : Simulation.Event<GotoNextLevel>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            if (player.health.IsAlive)
            {
                    player.health.Die();
                    model.virtualCamera.m_Follow = null;
                    model.virtualCamera.m_LookAt = null;
                    player.controlEnabled = false;

                    if (player.audioSource && player.levelCompleteAudio)
                        player.audioSource.PlayOneShot(player.levelCompleteAudio);
                    player.animator.SetTrigger("hurt");
                    player.animator.SetBool("dead", true);
                    Simulation.Schedule<PlayerSpawnNextLevel>(2);
            }
        }
    }
}