using Layer_Up.Scripts.Core;
using Layer_Up.Scripts.Mechanics;
using Layer_Up.Scripts.Mechanics.EnvironmentInteractables;
using Layer_Up.Scripts.Model;
namespace Layer_Up.Scripts.Gameplay
{
    /// <summary>
    /// Fired when the player is spawned after dying.
    /// </summary>
    public class PlayerSpawnNextLevel : Simulation.Event<PlayerSpawnNextLevel>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            LevelManager.StartNextLevel();
            var player = model.player;
            player.collider2d.enabled = true;
            player.controlEnabled = false;
            if (player.audioSource && player.levelStartedAudio)
                player.audioSource.PlayOneShot(player.levelStartedAudio);
            player.health.Increment();
            player.Teleport(model.spawnPoint.transform.position);
            player.jumpState = PlayerController.JumpState.Grounded;
            player.animator.SetBool("dead", false);
            model.virtualCamera.m_Follow = player.transform;
            model.virtualCamera.m_LookAt = player.transform;
            Simulation.Schedule<EnablePlayerInput>(2f);
        }
    }
}