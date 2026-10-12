using UnityEngine;
using UnityEngine.UI;

namespace Strike
{
    public class StrikeHUD : MonoBehaviour
    {
        private Text healthText;
        private Text stateText;
        private Text timerText;
        private GameObject player;

        private void Awake()
        {
            SetupCanvas();
            SetupTexts();
        }

        private void Update()
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player");
            }

            if (player != null)
            {
                var health = player.GetComponent<StrikeHealth>();
                if (health != null)
                {
                    healthText.text = "Health: " + Mathf.RoundToInt(health.CurrentHealth) + "%";
                }
            }
        }

        public void BindPlayer(GameObject playerObject)
        {
            player = playerObject;
        }

        public void UpdateMatchState(StrikeMatchState state, float remainingTime)
        {
            if (stateText == null)
            {
                return;
            }

            stateText.text = "State: " + state.ToString();
            timerText.text = "Time: " + Mathf.Max(0f, remainingTime).ToString("0.0") + "s";
        }

        private void SetupCanvas()
        {
            Canvas canvas = GetComponent<Canvas>();
            if (canvas == null)
            {
                canvas = gameObject.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            }

            CanvasScaler scaler = GetComponent<CanvasScaler>();
            if (scaler == null)
            {
                scaler = gameObject.AddComponent<CanvasScaler>();
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = new Vector2(1920f, 1080f);
            }

            if (GetComponent<GraphicRaycaster>() == null)
            {
                gameObject.AddComponent<GraphicRaycaster>();
            }
        }

        private void SetupTexts()
        {
            healthText = CreateText("HealthText", new Vector2(30f, -30f), 24, new Color(0.9f, 0.95f, 1f), TextAnchor.UpperLeft);
            stateText = CreateText("StateText", new Vector2(30f, -90f), 20, new Color(0.85f, 0.85f, 1f), TextAnchor.UpperLeft);
            timerText = CreateText("TimerText", new Vector2(30f, -150f), 20, new Color(0.85f, 0.85f, 1f), TextAnchor.UpperLeft);
        }

        private Text CreateText(string name, Vector2 anchoredPosition, int fontSize, Color color, TextAnchor alignment)
        {
            var textObject = new GameObject(name);
            textObject.transform.SetParent(transform);

            RectTransform rect = textObject.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0f, 1f);
            rect.anchorMax = new Vector2(0f, 1f);
            rect.pivot = new Vector2(0f, 1f);
            rect.anchoredPosition = anchoredPosition;
            rect.sizeDelta = new Vector2(500f, 60f);

            Text text = textObject.AddComponent<Text>();
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.text = "";
            text.fontSize = fontSize;
            text.color = color;
            text.alignment = alignment;
            return text;
        }
    }
}
