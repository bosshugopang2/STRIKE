using UnityEngine;

namespace Strike
{
    public class StrikePlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 6f;
        [SerializeField] private float gravity = -25f;
        [SerializeField] private float jumpForce = 7f;
        [SerializeField] private float lookSensitivity = 2.2f;
        [SerializeField] private float pitchClamp = 85f;

        private CharacterController controller;
        private Transform cameraPivot;
        private Camera playerCamera;
        private Vector3 velocity;
        private float pitch;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            HandleMovement();
            HandleLook();
        }

        public void SetCameraRig()
        {
            if (cameraPivot == null)
            {
                cameraPivot = new GameObject("CameraPivot").transform;
                cameraPivot.SetParent(transform);
                cameraPivot.localPosition = new Vector3(0f, 0.7f, 0f);
            }

            if (playerCamera == null)
            {
                playerCamera = Camera.main;
                if (playerCamera == null)
                {
                    var cameraObject = new GameObject("Main Camera");
                    cameraObject.tag = "MainCamera";
                    cameraObject.transform.SetParent(cameraPivot);
                    cameraObject.transform.localPosition = new Vector3(0f, 0.3f, 0.2f);
                    playerCamera = cameraObject.AddComponent<Camera>();
                    cameraObject.AddComponent<AudioListener>();
                }
            }

            if (playerCamera != null)
            {
                playerCamera.transform.SetParent(cameraPivot);
                playerCamera.transform.localPosition = new Vector3(0f, 0.3f, 0.2f);
                playerCamera.transform.localRotation = Quaternion.identity;
            }
        }

        public void JumpForMobile()
        {
            if (controller != null && controller.isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            }
        }

        private void HandleMovement()
        {
            bool grounded = controller.isGrounded;
            Vector2 input = StrikeInputManager.MoveInput();
            Vector3 move = new Vector3(input.x, 0f, input.y);
            move = transform.TransformDirection(move).normalized;

            if (grounded && velocity.y < 0f)
            {
                velocity.y = -2f;
            }

            if (StrikeInputManager.JumpPressed() && grounded)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            }

            velocity.x = move.x * moveSpeed;
            velocity.z = move.z * moveSpeed;
            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }

        private void HandleLook()
        {
            if (playerCamera == null || cameraPivot == null)
            {
                return;
            }

            Vector2 lookInput = StrikeInputManager.LookInput();
            transform.Rotate(0f, lookInput.x * lookSensitivity, 0f);
            pitch -= lookInput.y * lookSensitivity;
            pitch = Mathf.Clamp(pitch, -pitchClamp, pitchClamp);
            cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        }
    }
}
