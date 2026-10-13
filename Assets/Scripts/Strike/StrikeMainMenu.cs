using UnityEngine;

namespace Strike
{
    public class StrikeLobbyManager : MonoBehaviour
    {
        [SerializeField] private string lobbyName = "STRIKE Lobby";
        [SerializeField] private int requiredPlayers = 1;
        [SerializeField] private bool lobbyOpen = true;
        [SerializeField] private float countdown = 3f;

        private void Update()
        {
            if (!lobbyOpen)
            {
                return;
            }

            if (GetPlayersConnected() >= requiredPlayers)
            {
                countdown -= Time.deltaTime;
                if (countdown <= 0f)
                {
                    StartMatch();
                }
            }
            else
            {
                countdown = 3f;
            }
        }

        public void StartMatch()
        {
            lobbyOpen = false;
            var manager = FindObjectOfType<StrikeGameManager>();
            if (manager != null)
            {
                manager.SetState(StrikeMatchState.Active);
            }
        }

        public int GetPlayersConnected() { return 1; }
        public string LobbyNameValue => lobbyName;
    }
}
