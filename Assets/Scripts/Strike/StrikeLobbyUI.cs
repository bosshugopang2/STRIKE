using UnityEngine;
using UnityEngine.UI;

namespace Strike
{
    public class StrikeTargetingReticle : MonoBehaviour
    {
        private Image reticle;

        private void Awake()
        {
            var canvasObj = new GameObject("ReticleCanvas");
            canvasObj.transform.SetParent(transform);
            var canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObj.AddComponent<GraphicRaycaster>();

            var obj = new GameObject("Reticle");
            obj.transform.SetParent(canvasObj.transform);
            var rect = obj.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.sizeDelta = new Vector2(18f, 18f);
            reticle = obj.AddComponent<Image>();
            reticle.color = new Color(1f, 1f, 1f, 0.9f);
        }
    }
}
