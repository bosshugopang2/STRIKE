using UnityEngine;
using UnityEngine.UI;

namespace Strike
{
    public class StrikeResultsPanel : MonoBehaviour
    {
        private Text titleText;
        private Text summaryText;

        private void Awake()
        {
            SetupCanvas();
            SetupText();
        }

        public void ShowResults(bool won, int score, int enemiesLeft)
        {
            titleText.text = won ? "VICTORY" : "DEFEAT";
            summaryText.text = "Score: " + score + "\nEnemies Remaining: " + enemiesLeft;
            gameObject.SetActive(true);
        }

        public void HideResults()
        {
            gameObject.SetActive(false);
        }

        private void SetupCanvas()
        {
            if (GetComponent<Canvas>() == null)
            {
                var canvas = gameObject.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            }

            if (GetComponent<GraphicRaycaster>() == null)
            {
                gameObject.AddComponent<GraphicRaycaster>();
            }
        }

        private void SetupText()
        {
            var titleObject = new GameObject("Title");
            titleObject.transform.SetParent(transform);
            var titleRect = titleObject.AddComponent<RectTransform>();
            titleRect.anchorMin = new Vector2(0.5f, 0.5f);
            titleRect.anchorMax = new Vector2(0.5f, 0.5f);
            titleRect.sizeDelta = new Vector2(400f, 80f);
            titleRect.anchoredPosition = new Vector2(0f, 60f);
            titleText = titleObject.AddComponent<Text>();
            titleText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            titleText.alignment = TextAnchor.MiddleCenter;
            titleText.fontSize = 40;
            titleText.color = Color.white;

            var summaryObject = new GameObject("Summary");
            summaryObject.transform.SetParent(transform);
            var summaryRect = summaryObject.AddComponent<RectTransform>();
            summaryRect.anchorMin = new Vector2(0.5f, 0.5f);
            summaryRect.anchorMax = new Vector2(0.5f, 0.5f);
            summaryRect.sizeDelta = new Vector2(420f, 140f);
            summaryRect.anchoredPosition = new Vector2(0f, -30f);
            summaryText = summaryObject.AddComponent<Text>();
            summaryText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            summaryText.alignment = TextAnchor.MiddleCenter;
            summaryText.fontSize = 22;
            summaryText.color = Color.white;

            HideResults();
        }
    }
}
