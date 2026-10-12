using UnityEngine;
using UnityEngine.UI;

namespace Strike
{
    public class StrikeMatchUI : MonoBehaviour
    {
        private Text healthText;
        private Text timerText;
        private Text stateText;

        private void Awake()
        {
            BuildCanvas();
            BuildTexts();
        }

        private void Update()
        {
            var player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                var health = player.GetComponent<StrikeHealth>();
                if (health != null)
                {
                    healthText.text = "Health: " + Mathf.RoundToInt(health.CurrentHealth) + "%";
                }
            }

            var manager = FindObjectOfType<StrikeGameManager>();
            if (manager != null)
            {
                timerText.text = "Time: " + Mathf.Max(0f, manager.TimeRemaining).ToString("0.0") + "s";
                stateText.text = "State: " + manager.MatchState.ToString();
            }
        }

        private void BuildCanvas()
        {
            if (GetComponent<Canvas>() == null)
            {
                var canvas = gameObject.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            }

            if (GetComponent<CanvasScaler>() == null)
            {
                var scaler = gameObject.AddComponent<CanvasScaler>();
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = new Vector2(1920f, 1080f);
            }

            if (GetComponent<GraphicRaycaster>() == null)
            {
                gameObject.AddComponent<GraphicRaycaster>();
            }
        }

        private void BuildTexts()
        {
            healthText = CreateText("HealthText", new Vector2(30f, -30f), 24, Color.white, TextAnchor.UpperLeft);
            timerText = CreateText("TimerText", new Vector2(30f, -90f), 20, Color.white, TextAnchor.UpperLeft);
            stateText = CreateText("StateText", new Vector2(30f, -150f), 20, Color.white, TextAnchor.UpperLeft);
        }

        private Text CreateText(string name, Vector2 position, int fontSize, Color color, TextAnchor align)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(transform);

            var rect = obj.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0f, 1f);
            rect.anchorMax = new Vector2(0f, 1f);
            rect.pivot = new Vector2(0f, 1f);
            rect.anchoredPosition = position;
            rect.sizeDelta = new Vector2(420f, 60f);

            var text = obj.AddComponent<Text>();
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.fontSize = fontSize;
            text.color = color;
            text.alignment = align;
            return text;
        }
    }
}
