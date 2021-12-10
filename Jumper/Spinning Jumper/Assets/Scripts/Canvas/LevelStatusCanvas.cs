using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace com.flyingcrow.jumper.canvas
{
    public class LevelStatusCanvas : MonoBehaviour
    {

        [SerializeField]
        private TextMeshProUGUI titleText;
        [SerializeField]
        private Slider progressSlider;
        [SerializeField]
        private TextMeshProUGUI progressText;
        [SerializeField]
        private Image progressHandle;

        public void StartLevelView(string levelName, float progress, Sprite playerSprite)
        {
            titleText.text = levelName;
            progressSlider.value = progress;
            progressText.text = "Progress: " + progress;
            progressHandle.sprite = playerSprite;
            this.gameObject.SetActive(true);
        }

    }
}
