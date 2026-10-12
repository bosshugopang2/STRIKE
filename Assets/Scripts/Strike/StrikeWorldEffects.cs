using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Strike
{
    public class StrikeKillFeed : MonoBehaviour
    {
        private readonly List<string> messages = new List<string>();
        private Text feedText;

        private void Awake()
        {
            var obj = new GameObject("KillFeed");
            obj.transform.SetParent(transform);
            var rect = obj.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0f);
            rect.anchorMax = new Vector2(0.5f, 0f);
            rect.sizeDelta = new Vector2(600f, 200f);
            rect.anchoredPosition = new Vector2(0f, 80f);
            feedText = obj.AddComponent<Text>();
            feedText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            feedText.fontSize = 18;
            feedText.alignment = TextAnchor.MiddleCenter;
            feedText.color = Color.white;
        }

        public void AddMessage(string message)
        {
            messages.Add(message);
            if (messages.Count > 5)
            {
                messages.RemoveAt(0);
            }

            feedText.text = string.Join("\n", messages);
        }
    }
}
