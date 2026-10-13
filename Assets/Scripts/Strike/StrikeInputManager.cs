using UnityEngine;

namespace Strike
{
    public class StrikeWeaponSwap : MonoBehaviour
    {
        [SerializeField] private string[] weapons = { "Rifle", "SMG", "Shotgun" };
        private int index;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                index = (index + 1) % weapons.Length;
                Debug.Log("Weapon: " + weapons[index]);
            }
        }
    }
}
