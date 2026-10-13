using UnityEngine;

namespace Strike
{
    public class StrikeMainMenu : MonoBehaviour
    {
        public void StartMatch()
        {
            var manager = FindObjectOfType<StrikeGameManager>();
            if (manager != null)
            {
                manager.SetState(StrikeMatchState.Active);
            }
            Time.timeScale = 1f;
        }

        public void TogglePause()
        {
            Time.timeScale = Time.timeScale == 0f ? 1f : 0f;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
