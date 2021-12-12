using UnityEngine;
using UnityEngine.UI;
using TMPro;
using com.flyingcrow.jumper.events;

namespace com.flyingcrow.jumper.canvas
{
    public class LevelStatusCanvas : MonoBehaviour
    {
        [SerializeField]
        private EventManager eventManager;
        [SerializeField]
        private TextMeshProUGUI titleText;
        [SerializeField]
        private Slider progressSlider;
        [SerializeField]
        private TextMeshProUGUI progressText;
        [SerializeField]
        private Image progressHandle;
        [SerializeField]
        private Button playButton;
        [SerializeField]
        private TextMeshProUGUI attemptsText;
        [SerializeField]
        private Toggle autoPlay;
        private float targetProgress;

        private void Start()
        {
            if (!eventManager)
            {
                Debug.LogWarning("No EventManager found!");
            }
            eventManager.SubscribeRestarting(RestartLevel);
            this.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (this.gameObject.activeSelf && progressSlider.value != targetProgress)
            {
                progressSlider.value = Mathf.Lerp(progressSlider.value, targetProgress, 5 * Time.deltaTime);
                if (progressSlider.value >= targetProgress - 0.01f)
                {
                    progressSlider.value = targetProgress;
                }
                progressText.text = "Progress: " + progressSlider.value.ToString("F0") + "%";
            }
        }

        public void StartLevelView(string levelName, float highScore, float progress, Sprite playerSprite, int deaths, bool paused)
        {
            if ((highScore < progress) || !autoPlay.isOn || paused)
            {
                titleText.text = levelName;
                progressSlider.value = 0;
                targetProgress = progress;
                progressText.text = "Progress: " + 0;
                progressHandle.sprite = playerSprite;
                attemptsText.text = "Attempts: " + deaths;
                this.gameObject.SetActive(true);
                if (!paused)
                {
                    playButton.onClick.RemoveAllListeners();
                    playButton.onClick.AddListener(eventManager.InvokeRestarting);
                } 
                else
                {
                    playButton.onClick.RemoveAllListeners();
                    playButton.onClick.AddListener(eventManager.InvokeResume);
                }
            } 
            else
            {
                eventManager.InvokeRestarting();
            }
        }

        private void RestartLevel()
        {
            this.gameObject.SetActive(false);
        }

    }
}
