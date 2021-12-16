using com.flyingcrow.jumper.events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.flyingcrow.jumper.canvas
{
    [RequireComponent(typeof(Canvas))]
    public class LevelGameLayoutCanvas : MonoBehaviour
    {
        [SerializeField]
        private EventManager eventManager;

        private void Start()
        {
            if (!eventManager)
            {
                Debug.LogWarning("No EventManager found in LevelGameLayoutCanvas!!");
            }
            eventManager.SubscribeRestarting(RestartOrResumeLevel);
            eventManager.SubscribeResume(RestartOrResumeLevel);
            eventManager.SubscribePause(PauseLevel);
        }

        public void SetInformation()
        {

        }

        private void RestartOrResumeLevel()
        {
            this.GetComponent<Canvas>().enabled = true;
        }

        private void PauseLevel()
        {
            this.GetComponent<Canvas>().enabled = false;
        }
    }
}
