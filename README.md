using UnityEngine;
using UnityEngine.UI;

namespace Strike
{
    public class StrikeScoreboard : MonoBehaviour
    {
        private Text scoreText;
        private Text enemiesText;

        private void Awake()
        {
            SetupCanvas();
            SetupTexts();
        }

        private void Update()
        {
            var manager = FindObjectOfType<StrikeGameManager>();
            if (manager == null)
            {
                return;
            }

            scoreText.text = "Score: " + manager.Score;
            enemiesText.text = "Enemies: " + FindObjectsOfType<StrikeEnemyBot>().Length;
        }

        private void SetupCanvas()
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

        private void SetupTexts()
        {
            scoreText = CreateText("ScoreText", new Vector2(-180f, -30f), 22, new Color(1f, 0.9f, 0.4f), TextAnchor.UpperRight);
            enemiesText = CreateText("EnemiesText", new Vector2(-180f, -80f), 18, new Color(0.75f, 0.9f, 1f), TextAnchor.UpperRight);
        }

        private Text CreateText(string name, Vector2 anchoredPosition, int fontSize, Color color, TextAnchor alignment)
        {
            var textObject = new GameObject(name);
            textObject.transform.SetParent(transform);

            RectTransform rect = textObject.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(1f, 1f);
            rect.anchorMax = new Vector2(1f, 1f);
            rect.pivot = new Vector2(1f, 1f);
            rect.anchoredPosition = anchoredPosition;
            rect.sizeDelta = new Vector2(250f, 40f);

            var text = textObject.AddComponent<Text>();
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.text = "";
            text.fontSize = fontSize;
            text.color = color;
            text.alignment = alignment;
            return text;
        }
    }
}
