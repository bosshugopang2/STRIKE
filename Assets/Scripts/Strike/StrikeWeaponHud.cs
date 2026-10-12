using UnityEngine;
using UnityEngine.UI;

namespace Strike
{
    public class StrikeWeaponHud : MonoBehaviour
    {
        private Text ammoText;
        private Text weaponText;
        private Canvas canvas;

        private void Awake()
        {
            SetupCanvas();
            SetupText();
        }

        private void Update()
        {
            var weapon = FindObjectOfType<StrikeWeaponController>();
            if (weapon == null)
            {
                return;
            }

            ammoText.text = "Ammo: " + weapon.GetAmmoText();
            weaponText.text = "Weapon: STRIKE Rifle";
        }

        private void SetupCanvas()
        {
            canvas = gameObject.GetComponent<Canvas>();
            if (canvas == null)
            {
                canvas = gameObject.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            }

            if (gameObject.GetComponent<CanvasScaler>() == null)
            {
                var scaler = gameObject.AddComponent<CanvasScaler>();
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = new Vector2(1920f, 1080f);
            }

            if (gameObject.GetComponent<GraphicRaycaster>() == null)
            {
                gameObject.AddComponent<GraphicRaycaster>();
            }
        }

        private void SetupText()
        {
            ammoText = CreateText("AmmoText", new Vector2(-150f, -60f), 22, new Color(0.9f, 0.95f, 1f));
            weaponText = CreateText("WeaponText", new Vector2(-150f, -110f), 18, new Color(0.8f, 0.85f, 1f));
        }

        private Text CreateText(string name, Vector2 position, int fontSize, Color color)
        {
            var textObject = new GameObject(name);
            textObject.transform.SetParent(transform);

            var rect = textObject.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(1f, 1f);
            rect.anchorMax = new Vector2(1f, 1f);
            rect.pivot = new Vector2(1f, 1f);
            rect.anchoredPosition = position;
            rect.sizeDelta = new Vector2(250f, 40f);

            var text = textObject.AddComponent<Text>();
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.text = "";
            text.fontSize = fontSize;
            text.alignment = TextAnchor.UpperRight;
            text.color = color;
            return text;
        }
    }
}
