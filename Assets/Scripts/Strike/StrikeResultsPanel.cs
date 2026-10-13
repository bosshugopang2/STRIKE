using UnityEngine;
using UnityEngine.UI;

namespace Strike
{
    public class StrikeCrosshair : MonoBehaviour
    {
        private void Awake()
        {
            SetupCanvas();
            SetupReticle();
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

        private void SetupReticle()
        {
            var root = new GameObject("ReticleRoot");
            root.transform.SetParent(transform);
            var rect = root.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.sizeDelta = new Vector2(40f, 40f);
            rect.anchoredPosition = Vector2.zero;

            CreateBar(root.transform, "Horizontal", new Vector2(0f, 0f), new Vector2(20f, 2f));
            CreateBar(root.transform, "Vertical", new Vector2(0f, 0f), new Vector2(2f, 20f));
        }

        private void CreateBar(Transform parent, string name, Vector2 position, Vector2 size)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent);
            var rect = obj.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.sizeDelta = size;
            rect.anchoredPosition = position;
            var image = obj.AddComponent<Image>();
            image.color = new Color(1f, 1f, 1f, 0.75f);
        }
    }
}
