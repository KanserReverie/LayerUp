using UnityEngine;
using UnityEngine.Events;

namespace Layer_Up.Mod_Assets.Mod_Resources.Scripts.Platformer
{
    public class SimpleTrigger : MonoBehaviour
    {

        public Rigidbody2D triggerBody; 
        public UnityEvent onTriggerEnter;


        void OnTriggerEnter2D(Collider2D other){
            //do not trigger if there's no trigger target object
            if (triggerBody == null) return;

            //only trigger if the triggerBody matches
            var hitRb = other.attachedRigidbody;
            if (hitRb == triggerBody){
                onTriggerEnter.Invoke();
            }
        }

    }
}
