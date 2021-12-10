using UnityEngine;
using UnityEngine.Events;

namespace com.flyingcrow.jumper.events
{
    public class EventManager : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent restartingLevel;
        [SerializeField]
        private UnityEvent playerDying;
        [SerializeField]
        private UnityEvent restartLevel;
        [SerializeField]
        private UnityEvent gravitySwitch;

        public void SubscribeRestartingLevel(UnityAction action)
        {
            restartingLevel.AddListener(action);
        }

        public void UnsubscribeRestartingLevel(UnityAction action)
        {
            restartingLevel.RemoveListener(action);
        }

        public void InvokeRestartingLevel()
        {
            restartingLevel.Invoke();
        }
        public void SubscribePlayerDying(UnityAction action)
        {
            playerDying.AddListener(action);
        }

        public void UnsubscribePlayerDying(UnityAction action)
        {
            playerDying.RemoveListener(action);
        }

        public void InvokePlayerDying()
        {
            playerDying.Invoke();
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

