using com.flyingcrow.jumper.events;
using UnityEngine;

namespace com.flyingcrow.jumper.controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private EventManager eventManager;
        [SerializeField]
        private string levelName;
        [SerializeField]
        private float percentage;
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

            eventManager.SubscribePlayerDying(PlayerDying);
            eventManager.SubscribeRestarting(RestartLevel);
        }

        public float GetProgress()
        {
            return percentage;
        }
        public string GetLevelName()
        {
            return levelName;
        }

        public void PlayerDying()
        {
            deathCounter++;
        }

        public void RestartLevel()
        {
            
        }
        
    }
}
