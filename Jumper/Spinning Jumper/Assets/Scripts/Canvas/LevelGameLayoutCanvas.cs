using com.flyingcrow.jumper.events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace com.flyingcrow.jumper.canvas
{
    [RequireComponent(typeof(Canvas))]
    public class LevelGameLayoutCanvas : MonoBehaviour
    {
        [SerializeField]
        private EventManager eventManager;
        [SerializeField]
        private TextMeshProUGUI titleText;
        [SerializeField]
        private TextMeshProUGUI playerNameText;
        [SerializeField]
        private Button pauseButton;
        [SerializeField]
        private Slider progressBarSlider;
        private Image sliderHandleImage;

        private void Start()
        {
            if (!eventManager)
            {
                Debug.LogWarning("No EventManager found in LevelGameLayoutCanvas!!");
            }
            eventManager.SubscribeRestarting(RestartOrResumeLevel);
            eventManager.SubscribeResume(RestartOrResumeLevel);
            eventManager.SubscribePause(PauseOrDeadLevel);
            eventManager.SubscribePlayerDead(PauseOrDeadLevel);
            eventManager.SubscribePlayerDying(BlockButton);
            pauseButton.onClick.AddListener(eventManager.InvokePause);
            sliderHandleImage = progressBarSlider.handleRect.GetChild(0).GetComponent<Image>();
        }

        public void SetInformation(string title, string player, Sprite sprite)
        {
            titleText.text = title;
            playerNameText.text = player;
            sliderHandleImage.sprite = sprite;
        }

        private void BlockButton()
        {
            pauseButton.enabled = false;
        }

        private void RestartOrResumeLevel()
        {
            this.GetComponent<Canvas>().enabled = true;
            pauseButton.enabled = true;
        }

        private void PauseOrDeadLevel()
        {
            this.GetComponent<Canvas>().enabled = false;
        }
    }
}
