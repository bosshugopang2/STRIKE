using UnityEngine;

namespace Strike
{
    public class StrikeWeaponSwap : MonoBehaviour
    {
        [SerializeField] private string[] weaponNames = { "Rifle", "SMG", "Shotgun" };
        private int currentIndex;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentIndex = (currentIndex + 1) % weaponNames.Length;
                Debug.Log("Swapped to: " + weaponNames[currentIndex]);
            }
        }
    }
}
