using com.flyingcrow.jumper.canvas;
using com.flyingcrow.jumper.events;
using System.Collections;
using System.Collections.Generic;
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
            eventManager.SubscribePlayerDead(EnableCanvas);
        }

        private void EnableCanvas()
        {
            canvas.StartLevelView(gameController.GetLevelName(), gameController.GetProgress(), playerController.GetPlayerSprite());
        }


    }
}
