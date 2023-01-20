using Layer_Up.Scripts.Core;
using Layer_Up.Scripts.Mechanics;
using Layer_Up.Scripts.Mechanics.EnvironmentInteractables;
using Layer_Up.Scripts.Model;
using UnityEngine;
namespace Layer_Up.Scripts.Gameplay
{
    /// <summary>
    /// Fired when a player collides with a token.
    /// </summary>
    /// <typeparam name="PlayerCollision"></typeparam>
    public class PlayerTokenCollision : Simulation.Event<PlayerTokenCollision>
    {
        public PlayerController player;
        public TokenInstance token;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(token.tokenCollectAudio, token.transform.position);
        }
    }
}