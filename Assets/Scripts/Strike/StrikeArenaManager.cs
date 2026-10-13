using UnityEngine;

namespace Strike
{
    public class StrikeBootstrap : MonoBehaviour
    {
        [SerializeField] private int botCount = 6;
        [SerializeField] private Vector3 playerSpawn = new Vector3(0f, 1.2f, 0f);

        private void Start()
        {
            EnsureCoreSystems();
            EnsureArena();
            EnsurePlayer();
            EnsureBots();
            EnsureUI();
        }

        private void EnsureCoreSystems()
        {
            if (FindObjectOfType<StrikeGameManager>() == null)
            {
                var managerObject = new GameObject("GameManager");
                managerObject.AddComponent<StrikeGameManager>();
            }

            if (FindObjectOfType<StrikeLobbyManager>() == null)
            {
                var lobbyObject = new GameObject("LobbyManager");
                lobbyObject.AddComponent<StrikeLobbyManager>();
            }

            if (FindObjectOfType<StrikeMainMenu>() == null)
            {
                var menuObject = new GameObject("MainMenu");
                menuObject.AddComponent<StrikeMainMenu>();
            }
        }

        private void EnsureArena()
        {
            if (FindObjectOfType<StrikeArenaManager>() == null)
            {
                var arenaObject = new GameObject("ArenaManager");
                arenaObject.AddComponent<StrikeArenaManager>();
            }

            var arena = FindObjectOfType<StrikeArenaManager>();
            if (arena != null)
            {
                arena.BuildArena();
            }
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
            player.transform.position = playerSpawn;

            var controller = player.AddComponent<CharacterController>();
            controller.height = 1.8f;
            controller.radius = 0.35f;
            controller.center = new Vector3(0f, 0.9f, 0f);

            player.AddComponent<StrikePlayerController>();
            player.AddComponent<StrikeWeaponController>();
            player.AddComponent<StrikeHealth>();
            player.AddComponent<StrikePlayerCameraRig>();
            player.AddComponent<StrikeWeaponSwap>();
        }

        private void EnsureBots()
        {
            if (FindObjectsOfType<StrikeEnemyAI>().Length >= botCount)
            {
                return;
            }

            var spawnPoints = new[]
            {
                new Vector3(8f, 1.2f, 8f),
                new Vector3(-9f, 1.2f, 8f),
                new Vector3(9f, 1.2f, -8f),
                new Vector3(-8f, 1.2f, -8f),
                new Vector3(0f, 1.2f, 10f),
                new Vector3(0f, 1.2f, -10f)
            };

            for (int i = 0; i < botCount; i++)
            {
                var bot = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                bot.name = "Bot_" + i;
                bot.transform.position = spawnPoints[i % spawnPoints.Length];
                var controller = bot.AddComponent<CharacterController>();
                controller.height = 1.8f;
                controller.radius = 0.35f;
                controller.center = new Vector3(0f, 0.9f, 0f);
                bot.AddComponent<StrikeHealth>();
                bot.AddComponent<StrikeEnemyAI>();
            }
        }

        private void EnsureUI()
        {
            if (FindObjectOfType<StrikeHUD>() == null)
            {
                var hud = new GameObject("HUD");
                hud.AddComponent<StrikeHUD>();
            }

            if (FindObjectOfType<StrikeCrosshair>() == null)
            {
                var crosshair = new GameObject("Crosshair");
                crosshair.AddComponent<StrikeCrosshair>();
            }

            if (FindObjectOfType<StrikeResultsPanel>() == null)
            {
                var results = new GameObject("ResultsPanel");
                results.AddComponent<StrikeResultsPanel>();
            }
        }
    }
}
