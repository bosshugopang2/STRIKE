using UnityEngine;

namespace Strike
{
    public class StrikeInputManager
    {
        public static Vector2 MoveInput()
        {
            Vector2 keyboardInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (keyboardInput.sqrMagnitude > 0.01f)
            {
                return keyboardInput;
            }

            if (IsTouchMode())
            {
                var touchController = Object.FindObjectOfType<StrikeMobileInputController>();
                if (touchController != null)
                {
                    return touchController.MoveVector;
                }
            }

            return Vector2.zero;
        }

        public static Vector2 LookInput()
        {
            Vector2 mouseLook = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            if (mouseLook.sqrMagnitude > 0.01f)
            {
                return mouseLook;
            }

            if (IsTouchMode())
            {
                var touchController = Object.FindObjectOfType<StrikeMobileInputController>();
                if (touchController != null)
                {
                    return touchController.LookVector;
                }
            }

            return Vector2.zero;
        }

        public static bool FirePressed()
        {
            if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0))
            {
                return true;
            }

            if (IsTouchMode())
            {
                var touchController = Object.FindObjectOfType<StrikeMobileInputController>();
                return touchController != null && touchController.FirePressed;
            }

            return false;
        }

        public static bool JumpPressed()
        {
            return Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space);
        }

        public static bool IsTouchMode()
        {
            return Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WebGLPlayer;
        }
    }
}
