using UnityEngine;

namespace Strike
{
    public class StrikePlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float gravity = -20f;
        [SerializeField] private float lookSensitivity = 2f;

        private CharacterController controller;
        private Camera playerCamera;
        private Vector3 velocity;
        private float pitch;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            playerCamera = Camera.main;
            if (playerCamera != null)
            {
                playerCamera.transform.SetParent(transform);
                playerCamera.transform.localPosition = new Vector3(0f, 0.7f, 0.2f);
            }
        }

        private void Update()
        {
            HandleMovement();
            HandleLook();
        }

        private void HandleMovement()
        {
            var inputX = Input.GetAxis("Horizontal");
            var inputY = Input.GetAxis("Vertical");
            var movement = new Vector3(inputX, 0f, inputY).normalized;
            movement = transform.TransformDirection(movement);

            velocity.x = movement.x * moveSpeed;
            velocity.z = movement.z * moveSpeed;

            if (controller.isGrounded && velocity.y < 0f)
            {
                velocity.y = -2f;
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        private void HandleLook()
        {
            if (playerCamera == null)
            {
                return;
            }

            float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

            transform.Rotate(0f, mouseX, 0f);
            pitch -= mouseY;
            pitch = Mathf.Clamp(pitch, -85f, 85f);
            playerCamera.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        }
    }
}
