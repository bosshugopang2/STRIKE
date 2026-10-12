using UnityEngine;

namespace Strike
{
    public class StrikeMatchLoop : MonoBehaviour
    {
        private StrikeGameManager manager;

        private void Start()
        {
            manager = FindObjectOfType<StrikeGameManager>();
        }

        private void Update()
        {
            if (manager == null)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                var menu = FindObjectOfType<StrikeMenuController>();
                if (menu != null)
                {
                    menu.TogglePause();
                }
            }
        }
    }
}
