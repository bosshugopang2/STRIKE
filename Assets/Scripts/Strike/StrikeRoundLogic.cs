using UnityEngine;
using UnityEngine.UI;

namespace Strike
{
    public class StrikeLobbyUI : MonoBehaviour
    {
        private Text lobbyText;

        private void Awake()
        {
            if (GetComponent<Canvas>() == null)
            {
                var canvas = gameObject.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            }

            var obj = new GameObject("LobbyText");
            obj.transform.SetParent(transform);
            var rect = obj.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 1f);
            rect.anchorMax = new Vector2(0.5f, 1f);
            rect.anchoredPosition = new Vector2(0f, -40f);
            rect.sizeDelta = new Vector2(500f, 80f);
            lobbyText = obj.AddComponent<Text>();
            lobbyText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            lobbyText.fontSize = 30;
            lobbyText.alignment = TextAnchor.MiddleCenter;
            lobbyText.text = "STRIKE Lobby";
        }
    }
}
