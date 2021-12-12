using com.flyingcrow.jumper.canvas;
using com.flyingcrow.jumper.events;
using UnityEngine;

namespace com.flyingcrow.jumper.controller
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField]
        private LevelStatusCanvas canvas;
        [SerializeField]
        private EventManager eventManager;
        [SerializeField]
        private GameController gameController;
        [SerializeField]
        private PlayerController playerController;

        private void Start()
        {
            if (!eventManager)
            {
                Debug.LogWarning("No EventManager found!");
            }
            if (!gameController)
            {
                Debug.LogWarning("No GameController found!");
            }
            if (!canvas)
            {
                Debug.LogWarning("No Canvas found!");
            }
            if (!playerController)
            {
                Debug.LogWarning("No PlayerController found!");
            }
            eventManager.SubscribePlayerDead(EnableCanvasDead);
            eventManager.SubscribePause(EnableCanvasPause);
        }

        private void EnableCanvasDead()
        {
            ScoreAndHigh sah = gameController.CompletionPercentage();
            canvas.StartLevelView(gameController.GetLevelName(), sah.highScore, sah.score, playerController.GetPlayerSprite(), gameController.GetDeaths(), false);
        }

        private void EnableCanvasPause()
        {
            ScoreAndHigh sah = gameController.CompletionPercentage();
            canvas.StartLevelView(gameController.GetLevelName(), sah.highScore, sah.score, playerController.GetPlayerSprite(), gameController.GetDeaths(), true);
        }


    }
}
