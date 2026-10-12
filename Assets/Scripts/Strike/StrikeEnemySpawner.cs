using UnityEngine;

namespace Strike
{
    public class StrikeEnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int maxEnemies = 6;
        [SerializeField] private float spawnInterval = 3f;
        [SerializeField] private Vector3[] spawnPoints;

        private float timer;

        private void Start()
        {
            if (spawnPoints == null || spawnPoints.Length == 0)
            {
                spawnPoints = new[]
                {
                    new Vector3(7f, 1f, 9f),
                    new Vector3(-8f, 1f, 9f),
                    new Vector3(9f, 1f, -8f),
                    new Vector3(-9f, 1f, -8f),
                    new Vector3(0f, 1f, 10f),
                    new Vector3(0f, 1f, -10f)
                };
            }
        }

        private void Update()
        {
            if (FindObjectsOfType<StrikeEnemyBot>().Length >= maxEnemies)
            {
                return;
            }

            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                SpawnEnemy();
                timer = spawnInterval;
            }
        }

        private void SpawnEnemy()
        {
            if (enemyPrefab == null)
            {
                var bot = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                bot.name = "EnemyBot_Spawned";
                bot.transform.localScale = new Vector3(1f, 1f, 1f);
                bot.AddComponent<CharacterController>();
                bot.AddComponent<StrikeHealth>();
                bot.AddComponent<StrikeEnemyBot>();
                enemyPrefab = bot;
            }

            var index = Random.Range(0, spawnPoints.Length);
            var spawnPos = spawnPoints[index];
            var instance = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            instance.name = "EnemyBot_" + Time.frameCount;
        }
    }
}
