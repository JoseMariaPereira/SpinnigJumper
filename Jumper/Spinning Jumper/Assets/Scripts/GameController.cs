using com.flyingcrow.jumper.events;
using UnityEngine;

namespace com.flyingcrow.jumper.controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private EventManager eventManager;
        [SerializeField]
        private int percentage;
        [SerializeField]
        private int deathCounter;
        [SerializeField]
        private float startPos;
        [SerializeField]
        private float endPos;



        // Start is called before the first frame update
        void Start()
        {
            if (!eventManager)
            {
                Debug.LogWarning("No eventManager found!");
            }

            eventManager.SubscribeRestartingLevel(PlayerDiedWindow);
            eventManager.SubscribeRestarting(RestartLevel);
        }

        public void PlayerDiedWindow()
        {
            deathCounter++;
            eventManager.InvokeRestarting();
        }

        public void RestartLevel()
        {
            Debug.Log(deathCounter);
        }
        
    }
}
