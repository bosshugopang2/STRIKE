using UnityEngine;
using UnityEngine.UI;

namespace Strike
{
    public class StrikeDamageFlash : MonoBehaviour
    {
        private Image flashImage;

        private void Awake()
        {
            var canvasObj = new GameObject("DamageFlashCanvas");
            canvasObj.transform.SetParent(transform);
            var canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            var raycaster = canvasObj.AddComponent<GraphicRaycaster>();
            var imageObj = new GameObject("DamageFlash");
            imageObj.transform.SetParent(canvasObj.transform);
            var rect = imageObj.AddComponent<RectTransform>();
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            flashImage = imageObj.AddComponent<Image>();
            flashImage.color = new Color(1f, 0f, 0f, 0f);
        }

        public void Trigger(float amount)
        {
            flashImage.color = new Color(1f, 0f, 0f, Mathf.Clamp01(amount / 50f));
        }
    }
}
