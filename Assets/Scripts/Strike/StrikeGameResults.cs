using UnityEngine;

namespace Strike
{
    public class StrikeGameResults : MonoBehaviour
    {
        public void ShowResults(bool won)
        {
            var menu = FindObjectOfType<StrikeMenuController>();
            if (menu != null)
            {
                menu.ShowResults();
            }

            Debug.Log(won ? "STRIKE Victory" : "STRIKE Defeat");
        }
    }
}
