using UnityEngine;
using UnityEngine.UI;

namespace Strike
{
    public class StrikeHUD : MonoBehaviour
    {
        private Canvas canvas;
        private Text healthText;
        private Text stateText;
        private Text timerText;
        private GameObject player;

        private void Awake()
        {
            SetupCanvas();
            SetupText();
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
            canvas = gameObject.GetComponent<Canvas>();
            if (canvas == null)
            {
                canvas = gameObject.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            }

            var scaler = gameObject.GetComponent<CanvasScaler>();
            if (scaler == null)
            {
                scaler = gameObject.AddComponent<CanvasScaler>();
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = new Vector2(1920f, 1080f);
            }

            var graphics = gameObject.GetComponent<GraphicRaycaster>();
            if (graphics == null)
            {
                gameObject.AddComponent<GraphicRaycaster>();
            }
        }

        private void SetupText()
        {
            healthText = CreateText("HealthText", new Vector2(30f, -30f), 24, new Color(0.9f, 0.95f, 1f));
            stateText = CreateText("StateText", new Vector2(30f, -90f), 20, new Color(0.85f, 0.85f, 1f));
            timerText = CreateText("TimerText", new Vector2(30f, -150f), 20, new Color(0.85f, 0.85f, 1f));
        }

        private Text CreateText(string name, Vector2 position, int fontSize, Color color)
        {
            var textObject = new GameObject(name);
            textObject.transform.SetParent(transform);

            var rect = textObject.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0f, 1f);
            rect.anchorMax = new Vector2(0f, 1f);
            rect.pivot = new Vector2(0f, 1f);
            rect.anchoredPosition = position;
            rect.sizeDelta = new Vector2(500f, 60f);

            var text = textObject.AddComponent<Text>();
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.text = name.StartsWith("Health") ? "Health: 100%" : "State: Active";
            text.fontSize = fontSize;
            text.color = color;
            text.alignment = TextAnchor.UpperLeft;
            return text;
        }
    }
}
