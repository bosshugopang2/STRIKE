using UnityEngine;
using UnityEngine.UI;

namespace Strike
{
    public class StrikeCrosshair : MonoBehaviour
    {
        private Image centerDot;
        private Image horizontalLine;
        private Image verticalLine;

        private void Awake()
        {
            SetupCrosshair();
        }

        private void SetupCrosshair()
        {
            var canvasObject = new GameObject("CrosshairCanvas");
            canvasObject.transform.SetParent(transform);
            var canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();

            var root = new GameObject("CrosshairRoot");
            root.transform.SetParent(canvasObject.transform);
            var rect = root.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = Vector2.zero;
            rect.sizeDelta = new Vector2(60f, 60f);

            centerDot = CreateImage(root.transform, "CenterDot", new Vector2(0f, 0f), new Vector2(6f, 6f), new Color(1f, 1f, 1f, 0.85f));
            horizontalLine = CreateImage(root.transform, "HorizontalLine", new Vector2(0f, 0f), new Vector2(22f, 2f), new Color(1f, 1f, 1f, 0.8f));
            verticalLine = CreateImage(root.transform, "VerticalLine", new Vector2(0f, 0f), new Vector2(2f, 22f), new Color(1f, 1f, 1f, 0.8f));
        }

        private Image CreateImage(Transform parent, string name, Vector2 anchorPosition, Vector2 size, Color color)
        {
            var imageObject = new GameObject(name);
            imageObject.transform.SetParent(parent);
            var rect = imageObject.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.sizeDelta = size;
            rect.anchoredPosition = anchorPosition;
            var image = imageObject.AddComponent<Image>();
            image.color = color;
            return image;
        }
    }
}
