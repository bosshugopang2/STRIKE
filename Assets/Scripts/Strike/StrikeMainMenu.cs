using UnityEngine;

namespace Strike
{
    public class StrikeMainMenu : MonoBehaviour
    {
        [SerializeField] private string lobbyName = "STRIKE Arena";
        [SerializeField] private int maxPlayers = 8;

        public void StartMatch()
        {
            var manager = FindObjectOfType<StrikeGameManager>();
            if (manager != null)
            {
                manager.SetState(StrikeMatchState.Active);
            }

            Time.timeScale = 1f;
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void TogglePause()
        {
            var menu = FindObjectOfType<StrikeMenuController>();
            if (menu != null)
            {
                menu.TogglePause();
            }
        }
    }
}
