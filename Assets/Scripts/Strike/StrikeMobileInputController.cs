using UnityEngine;

namespace Strike
{
    public class StrikeMobileInputController : MonoBehaviour
    {
        private Vector2 moveVector;
        private Vector2 lookVector;
        private bool firePressed;

        public Vector2 MoveVector => moveVector;
        public Vector2 LookVector => lookVector;
        public bool FirePressed => firePressed;

        private void Update()
        {
            if (!StrikeInputManager.IsTouchMode())
            {
                moveVector = Vector2.zero;
                lookVector = Vector2.zero;
                firePressed = false;
                return;
            }

            if (Input.touchCount > 0)
            {
                Touch primaryTouch = Input.GetTouch(0);
                moveVector = new Vector2(primaryTouch.deltaPosition.x, primaryTouch.deltaPosition.y).normalized;

                if (primaryTouch.phase == TouchPhase.Began || primaryTouch.phase == TouchPhase.Moved)
                {
                    firePressed = primaryTouch.position.x > Screen.width * 0.5f;
                }
                else
                {
                    firePressed = false;
                }

                lookVector = new Vector2(primaryTouch.deltaPosition.x * 0.2f, primaryTouch.deltaPosition.y * 0.2f);
            }
            else
            {
                moveVector = Vector2.zero;
                lookVector = Vector2.zero;
                firePressed = false;
            }
        }
    }
}
