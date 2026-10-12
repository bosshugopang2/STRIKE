using UnityEngine;

namespace Strike
{
    public class StrikeEnemyBot : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 2.5f;
        [SerializeField] private float attackRange = 1.8f;
        [SerializeField] private float attackDamage = 10f;
        [SerializeField] private float attackCooldown = 1.2f;
        [SerializeField] private float maxHealth = 50f;

        private CharacterController controller;
        private StrikeHealth health;
        private GameObject player;
        private float attackTimer;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            health = GetComponent<StrikeHealth>();
            if (health == null)
            {
                health = gameObject.AddComponent<StrikeHealth>();
            }

            health.SetMaxHealth(maxHealth);
            health.OnDeath += HandleDeath;
        }

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            attackTimer = 0f;
        }

        private void Update()
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player");
                return;
            }

            Vector3 toPlayer = player.transform.position - transform.position;
            float distance = toPlayer.magnitude;

            if (distance > 0.1f)
            {
                Vector3 desiredDirection = toPlayer.normalized;
                if (distance > attackRange)
                {
                    Vector3 movement = desiredDirection * moveSpeed;
                    movement.y = -2f;
                    controller.Move(movement * Time.deltaTime);
                }
            }

            if (distance <= attackRange)
            {
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0f)
                {
                    AttackPlayer();
                    attackTimer = attackCooldown;
                }
            }
        }

        private void AttackPlayer()
        {
            if (player == null)
            {
                return;
            }

            var playerHealth = player.GetComponent<StrikeHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }
        }

        private void HandleDeath(GameObject source)
        {
            var manager = FindObjectOfType<StrikeGameManager>();
            if (manager != null)
            {
                manager.RegisterEnemyDestroyed();
            }

            Destroy(gameObject, 0.1f);
        }
    }
}
