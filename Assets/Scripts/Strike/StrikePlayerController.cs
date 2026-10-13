using UnityEngine;

namespace Strike
{
    public static class StrikeInputManager
    {
        public static Vector2 MoveInput()
        {
            Vector2 keyboard = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (keyboard.sqrMagnitude > 0.01f)
            {
                return keyboard;
            }

            return Vector2.zero;
        }

        public static Vector2 LookInput()
        {
            return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }

        public static bool FirePressed()
        {
            return Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0);
        }

        public static bool JumpPressed()
        {
            return Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space);
        }
    }
}
