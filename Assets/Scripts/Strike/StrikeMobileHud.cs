using UnityEngine;
using UnityEngine.UI;

namespace Strike
{
    public class StrikeMobileHud : MonoBehaviour
    {
        private Button fireButton;
        private Button jumpButton;
        private Button pauseButton;

        private void Awake()
        {
            SetupCanvas();
            SetupButtons();
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

        private void SetupButtons()
        {
            fireButton = CreateButton("FireButton", new Vector2(-170f, 160f), new Vector2(180f, 140f), "FIRE");
            jumpButton = CreateButton("JumpButton", new Vector2(-420f, 160f), new Vector2(180f, 140f), "JUMP");
            pauseButton = CreateButton("PauseButton", new Vector2(-770f, 420f), new Vector2(120f, 80f), "||");

            fireButton.onClick.AddListener(() =>
            {
                var weapon = FindObjectOfType<StrikeWeaponController>();
                if (weapon != null)
                {
                    weapon.FireForMobile();
                }
            });

            jumpButton.onClick.AddListener(() =>
            {
                var player = FindObjectOfType<StrikePlayerController>();
                if (player != null)
                {
                    player.JumpForMobile();
                }
            });

            pauseButton.onClick.AddListener(() =>
            {
                var menu = FindObjectOfType<StrikeMenuController>();
                if (menu != null)
                {
                    menu.TogglePause();
                }
            });
        }

        private Button CreateButton(string name, Vector2 anchoredPosition, Vector2 size, string label)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(transform);

            RectTransform rect = obj.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(1f, 0f);
            rect.anchorMax = new Vector2(1f, 0f);
            rect.pivot = new Vector2(1f, 0f);
            rect.anchoredPosition = anchoredPosition;
            rect.sizeDelta = size;

            Image image = obj.AddComponent<Image>();
            image.color = new Color(0.20f, 0.28f, 0.38f, 0.8f);

            var textObj = new GameObject("Label");
            textObj.transform.SetParent(obj.transform);
            RectTransform textRect = textObj.AddComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = Vector2.one;
            textRect.offsetMin = Vector2.zero;
            textRect.offsetMax = Vector2.zero;

            Text text = textObj.AddComponent<Text>();
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.text = label;
            text.color = Color.white;
            text.alignment = TextAnchor.MiddleCenter;
            text.fontSize = 28;

            var button = obj.AddComponent<Button>();
            return button;
        }
    }
}
