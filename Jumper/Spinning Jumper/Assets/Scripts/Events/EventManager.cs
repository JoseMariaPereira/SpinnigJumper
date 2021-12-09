using UnityEngine;
using UnityEngine.Events;

namespace com.flyingcrow.jumper.events
{
    public class EventManager : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent playerDied;
        [SerializeField]
        private UnityEvent restartLevel;
        [SerializeField]
        private UnityEvent gravitySwitch;

        public void SubscribePlayerDied(UnityAction action)
        {
            playerDied.AddListener(action);
        }

        public void UnsubscribePlayerDied(UnityAction action)
        {
            playerDied.RemoveListener(action);
        }

        public void InvokePlayerDied()
        {
            playerDied.Invoke();
        }

        public void SubscribeRestarting(UnityAction action)
        {
            restartLevel.AddListener(action);
        }

        public void UnsubscribeRestarting(UnityAction action)
        {
            restartLevel.RemoveListener(action);
        }

        public void InvokeRestarting()
        {
            restartLevel.Invoke();
        }

        public void SubscribeGravity(UnityAction action)
        {
            gravitySwitch.AddListener(action);
        }

        public void UnsubscribeGravity(UnityAction action)
        {
            gravitySwitch.RemoveListener(action);
        }

        public void InvokeGravity()
        {
            gravitySwitch.Invoke();
        }
    }
}

