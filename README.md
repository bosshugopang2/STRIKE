using UnityEngine;
using UnityEngine.UI;

namespace Strike
{
    public class StrikeProximityWarning : MonoBehaviour
    {
        private Text warningText;

        private void Awake()
        {
            var obj = new GameObject("WarningText");
            obj.transform.SetParent(transform);
            var rect = obj.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.sizeDelta = new Vector2(320f, 80f);
            warningText = obj.AddComponent<Text>();
            warningText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            warningText.fontSize = 20;
            warningText.alignment = TextAnchor.MiddleCenter;
            warningText.color = Color.yellow;
            warningText.text = "Enemy nearby";
        }
    }
}
