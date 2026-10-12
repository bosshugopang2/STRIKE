using UnityEngine;

namespace Strike
{
    public class StrikeInputManager
    {
        public static Vector2 MoveInput()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        public static Vector2 LookInput()
        {
            return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }

        public static bool FirePressed()
        {
            return Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space);
        }

        public static bool JumpPressed()
        {
            return Input.GetButtonDown("Jump");
        }

        public static bool IsTouchMode()
        {
            return Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;
        }
    }
}
