using UnityEngine;

namespace Strike
{
    public class StrikeLobbyManager : MonoBehaviour
    {
        [SerializeField] private string lobbyName = "STRIKE Arena";
        [SerializeField] private int maxPlayers = 8;
        [SerializeField] private int requiredPlayersToStart = 1;
        [SerializeField] private bool autoStart = true;

        private bool isLobbyOpen = true;
        private float countdownTimer = 3f;

        private void Update()
        {
            if (!isLobbyOpen)
            {
                return;
            }

            if (autoStart && GetConnectedPlayers() >= requiredPlayersToStart)
            {
                countdownTimer -= Time.deltaTime;
                if (countdownTimer <= 0f)
                {
                    StartMatch();
                }
            }
            else
            {
                countdownTimer = 3f;
            }
        }

        public void StartMatch()
        {
            isLobbyOpen = false;
            var manager = FindObjectOfType<StrikeGameManager>();
            if (manager != null)
            {
                manager.SetState(StrikeMatchState.Active);
            }

            Time.timeScale = 1f;
        }

        public void LeaveLobby()
        {
            isLobbyOpen = false;
            Time.timeScale = 0f;
        }

        public int GetConnectedPlayers()
        {
            return Mathf.Max(1, maxPlayers > 0 ? 1 : 1);
        }

        public string LobbyName => lobbyName;
        public int MaxPlayers => maxPlayers;
    }
}
