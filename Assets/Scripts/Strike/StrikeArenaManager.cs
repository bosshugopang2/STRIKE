using UnityEngine;

namespace Strike
{
    public class StrikeGameBootstrap : MonoBehaviour
    {
        [SerializeField] private Vector3 playerSpawn = new Vector3(0f, 1.2f, 0f);
        [SerializeField] private int botCount = 6;

        private void Start()
        {
            EnsureRig();
            EnsureArena();
            EnsurePlayer();
            EnsureBots();
            EnsureHUD();
        }

        private void EnsureRig()
        {
            if (GameObject.Find("GameRig") == null)
            {
                var rig = new GameObject("GameRig");
                rig.AddComponent<StrikeArenaManager>();
                rig.AddComponent<StrikeMatchUI>();
                rig.AddComponent<StrikeAudioManager>();
                rig.AddComponent<StrikePickupSpawner>();
            }
        }

        private void EnsureArena()
        {
            var arena = FindObjectOfType<StrikeArenaManager>();
            if (arena != null)
            {
                arena.BuildArena();
            }
        }

        private void EnsurePlayer()
        {
            var player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                player.name = "Player";
                player.tag = "Player";
                player.transform.position = playerSpawn;

                var controller = player.AddComponent<CharacterController>();
                controller.height = 1.8f;
                controller.radius = 0.35f;
                controller.center = new Vector3(0f, 0.9f, 0f);

                player.AddComponent<StrikePlayerController>();
                player.AddComponent<StrikeWeaponSystem>();
                player.AddComponent<StrikeHealth>();
                player.AddComponent<StrikePlayerCameraRig>();
            }
        }

        private void EnsureBots()
        {
            if (FindObjectsOfType<StrikeEnemyAI>().Length >= botCount)
            {
                return;
            }

            var spawnPositions = new[]
            {
                new Vector3(7f, 1.2f, 8f),
                new Vector3(-9f, 1.2f, 7f),
                new Vector3(8f, 1.2f, -9f),
                new Vector3(-8f, 1.2f, -8f),
                new Vector3(0f, 1.2f, 11f),
                new Vector3(0f, 1.2f, -11f)
            };

            for (int i = 0; i < botCount; i++)
            {
                var bot = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                bot.name = "Bot_" + i;
                bot.transform.position = spawnPositions[i % spawnPositions.Length];

                var controller = bot.AddComponent<CharacterController>();
                controller.height = 1.8f;
                controller.radius = 0.35f;
                controller.center = new Vector3(0f, 0.9f, 0f);

                bot.AddComponent<StrikeHealth>();
                bot.AddComponent<StrikeEnemyAI>();
            }
        }

        private void EnsureHUD()
        {
            if (FindObjectOfType<StrikeMatchUI>() == null)
            {
                var hud = new GameObject("MatchOverlay");
                hud.AddComponent<StrikeMatchUI>();
            }
        }
    }
}
