using com.flyingcrow.jumper.events;
using UnityEngine;

namespace com.flyingcrow.jumper.controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private EventManager eventManager;
        [SerializeField]
        private GroundMoover groundController;
        [SerializeField]
        private PlayerController playerController;
        [SerializeField]
        private string levelName;
        [SerializeField]
        private int deathCounter;

        private float startDistance;

        private float highScore;



        // Start is called before the first frame update
        void Start()
        {
            if (!eventManager)
            {
                Debug.LogWarning("No eventManager found!");
            }
            startDistance = groundController.GetGoalPosition().x - playerController.GetStartPosition();
            eventManager.SubscribePlayerDying(PlayerDying);
        }

        public int GetDeaths()
        {
            return deathCounter;
        }

        public string GetLevelName()
        {
            return levelName;
        }

        public void PlayerDying()
        {
            deathCounter++;
        }

        public ScoreAndHigh CompletionPercentage()
        {
            ScoreAndHigh sah = new ScoreAndHigh();
            sah.highScore = highScore;
            sah.score = (groundController.GetGoalPosition().x - playerController.GetStartPosition() <= 0) ?
                100 :
                100 - ((groundController.GetGoalPosition().x - playerController.GetStartPosition()) * 100 / startDistance);
            if (sah.score > highScore)
            {
                highScore = sah.score;
            }
            return sah;
        }

    }

    public class ScoreAndHigh
    {
        public float highScore;
        public float score;
    }
}
