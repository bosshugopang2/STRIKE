using UnityEngine;

namespace Strike
{
    public class StrikeGameBootstrap : MonoBehaviour
    {
        [SerializeField] private Vector3 spawnPosition = new Vector3(0f, 1f, 0f);
        [SerializeField] private Color ambientLightColor = new Color(0.25f, 0.25f, 0.38f);

        private void Start()
        {
            EnsureLighting();
            EnsureMainCamera();
            EnsurePlayer();
            EnsureArena();
            EnsureHUD();
            EnsureGameManager();
        }

        private void EnsureLighting()
        {
            RenderSettings.ambientLight = ambientLightColor;
            RenderSettings.fog = true;
            RenderSettings.fogColor = new Color(0.08f, 0.08f, 0.12f);
            RenderSettings.fogMode = FogMode.ExponentialSquared;
            RenderSettings.fogDensity = 0.025f;
        }

        private void EnsureMainCamera()
        {
            if (Camera.main != null)
            {
                return;
            }

            var cameraObject = new GameObject("Main Camera");
            cameraObject.tag = "MainCamera";
            cameraObject.transform.position = new Vector3(0f, 1.6f, -8f);

            var camera = cameraObject.AddComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = new Color(0.08f, 0.08f, 0.13f);
            camera.fieldOfView = 70f;
            cameraObject.AddComponent<AudioListener>();
        }

        private void EnsurePlayer()
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                return;
            }

            var player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            player.name = "Player";
            player.tag = "Player";
            player.transform.position = spawnPosition;

            var controller = player.AddComponent<CharacterController>();
            controller.height = 1.8f;
            controller.radius = 0.35f;
            controller.center = new Vector3(0f, 0.9f, 0f);

            var playerController = player.AddComponent<StrikePlayerController>();
            playerController.SetCameraRig();

            var weapon = player.AddComponent<StrikeWeaponController>();
            weapon.SetWeaponOrigin(player.transform);

            var health = player.AddComponent<StrikeHealth>();
            health.SetMaxHealth(100f);

            var hud = FindObjectOfType<StrikeHUD>();
            if (hud != null)
            {
                hud.BindPlayer(player);
            }
        }

        private void EnsureArena()
        {
            var ground = GameObject.Find("Ground");
            if (ground == null)
            {
                ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
                ground.name = "Ground";
                ground.transform.position = Vector3.zero;
                ground.transform.localScale = new Vector3(8f, 1f, 8f);
                ground.GetComponent<Renderer>().material.color = new Color(0.15f, 0.2f, 0.15f);
            }

            var wallPositions = new[]
            {
                new Vector3(0f, 2f, 18f),
                new Vector3(0f, 2f, -18f),
                new Vector3(18f, 2f, 0f),
                new Vector3(-18f, 2f, 0f)
            };

            for (int i = 0; i < wallPositions.Length; i++)
            {
                var wall = GameObject.Find("ArenaWall_" + i);
                if (wall == null)
                {
                    wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.name = "ArenaWall_" + i;
                    wall.transform.position = wallPositions[i];
                    wall.transform.localScale = new Vector3(36f, 4f, 1f);
                    wall.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 0.35f);
                }
            }

            var targetPositions = new[]
            {
                new Vector3(5f, 1f, 8f),
                new Vector3(-7f, 1f, 6f),
                new Vector3(8f, 1f, -5f),
                new Vector3(-5f, 1f, -8f)
            };

            for (int i = 0; i < targetPositions.Length; i++)
            {
                var target = GameObject.Find("Target_" + i);
                if (target == null)
                {
                    target = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    target.name = "Target_" + i;
                    target.transform.position = targetPositions[i];
                    target.transform.localScale = new Vector3(1.2f, 2f, 1.2f);
                    target.GetComponent<Renderer>().material.color = new Color(0.9f, 0.25f, 0.25f);
                    target.AddComponent<StrikeTargetDummy>();
                }
            }
        }

        private void EnsureHUD()
        {
            if (FindObjectOfType<StrikeHUD>() != null)
            {
                return;
            }

            var hudObject = new GameObject("HUD");
            hudObject.AddComponent<StrikeHUD>();
        }

        private void EnsureGameManager()
        {
            if (FindObjectOfType<StrikeGameManager>() != null)
            {
                return;
            }

            var managerObject = new GameObject("GameManager");
            managerObject.AddComponent<StrikeGameManager>();
        }
    }
}
