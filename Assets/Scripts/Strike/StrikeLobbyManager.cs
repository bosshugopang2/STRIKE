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
            Hide();
        }

        public void Show(bool won, int score)
        {
            titleText.text = won ? "VICTORY" : "DEFEAT";
            summaryText.text = "Score: " + score;
            gameObject.SetActive(true);
        }

        public void Hide()
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
            var titleObj = new GameObject("TitleText");
            titleObj.transform.SetParent(transform);
            var titleRect = titleObj.AddComponent<RectTransform>();
            titleRect.anchorMin = new Vector2(0.5f, 0.5f);
            titleRect.anchorMax = new Vector2(0.5f, 0.5f);
            titleRect.sizeDelta = new Vector2(300f, 80f);
            titleRect.anchoredPosition = new Vector2(0f, 40f);
            titleText = titleObj.AddComponent<Text>();
            titleText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            titleText.fontSize = 40;
            titleText.alignment = TextAnchor.MiddleCenter;
            titleText.color = Color.white;

            var summaryObj = new GameObject("SummaryText");
            summaryObj.transform.SetParent(transform);
            var summaryRect = summaryObj.AddComponent<RectTransform>();
            summaryRect.anchorMin = new Vector2(0.5f, 0.5f);
            summaryRect.anchorMax = new Vector2(0.5f, 0.5f);
            summaryRect.sizeDelta = new Vector2(320f, 80f);
            summaryRect.anchoredPosition = new Vector2(0f, -20f);
            summaryText = summaryObj.AddComponent<Text>();
            summaryText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            summaryText.fontSize = 24;
            summaryText.alignment = TextAnchor.MiddleCenter;
            summaryText.color = Color.white;
        }
    }
}
