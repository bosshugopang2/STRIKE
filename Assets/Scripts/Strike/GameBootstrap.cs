using UnityEngine;

namespace Strike
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private Vector3 spawnPosition = new Vector3(0f, 1f, 0f);

        private void Start()
        {
            CreateMainCamera();
            CreatePlayer();
            SetupScene();
        }

        private void SetupScene()
        {
            RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.35f);
            if (Camera.main != null)
            {
                Camera.main.clearFlags = CameraClearFlags.SolidColor;
                Camera.main.backgroundColor = new Color(0.08f, 0.08f, 0.15f);
            }
        }

        private void CreateMainCamera()
        {
            if (Camera.main != null)
            {
                return;
            }

            var cameraObject = new GameObject("Main Camera");
            cameraObject.tag = "MainCamera";
            cameraObject.transform.position = new Vector3(0f, 1.5f, -8f);

            var camera = cameraObject.AddComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = new Color(0.08f, 0.08f, 0.15f);
            cameraObject.AddComponent<AudioListener>();
        }

        private void CreatePlayer()
        {
            var player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            player.name = "Player";
            player.transform.position = spawnPosition;
            player.tag = "Player";

            var controller = player.AddComponent<CharacterController>();
            controller.height = 1.8f;
            controller.radius = 0.35f;
            controller.center = new Vector3(0f, 0.9f, 0f);

            player.AddComponent<StrikePlayerController>();

            var ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "Ground";
            ground.transform.position = Vector3.zero;
            ground.transform.localScale = new Vector3(5f, 1f, 5f);
        }
    }
}
