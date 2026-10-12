using UnityEngine;

namespace Strike
{
    public class StrikeMenuController : MonoBehaviour
    {
        public enum MenuScreen
        {
            Main,
            Match,
            Pause,
            Results
        }

        [SerializeField] private MenuScreen currentScreen = MenuScreen.Main;
        [SerializeField] private bool isPaused;

        public MenuScreen CurrentScreen => currentScreen;

        public void ShowMainMenu()
        {
            currentScreen = MenuScreen.Main;
            isPaused = false;
            Time.timeScale = 1f;
        }

        public void StartMatch()
        {
            currentScreen = MenuScreen.Match;
            isPaused = false;
            Time.timeScale = 1f;

            var manager = FindObjectOfType<StrikeGameManager>();
            if (manager != null)
            {
                manager.SetState(StrikeMatchState.Active);
            }
        }

        public void TogglePause()
        {
            isPaused = !isPaused;
            currentScreen = isPaused ? MenuScreen.Pause : MenuScreen.Match;
            Time.timeScale = isPaused ? 0f : 1f;
        }

        public void ShowResults()
        {
            currentScreen = MenuScreen.Results;
            isPaused = true;
            Time.timeScale = 0f;
        }
    }
}
