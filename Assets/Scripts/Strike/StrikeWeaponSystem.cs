using UnityEngine;

namespace Strike
{
    public class StrikeEnemyAI : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 2.8f;
        [SerializeField] private float attackRange = 1.8f;
        [SerializeField] private float damage = 10f;
        [SerializeField] private float attackCooldown = 1.2f;
        [SerializeField] private float maxHealth = 60f;

        private CharacterController controller;
        private GameObject player;
        private float cooldownTimer;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            var health = GetComponent<StrikeHealth>();
            if (health == null)
            {
                health = gameObject.AddComponent<StrikeHealth>();
            }
            health.SetMaxHealth(maxHealth);
        }

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player");
                return;
            }

            Vector3 toPlayer = player.transform.position - transform.position;
            float dist = toPlayer.magnitude;

            if (dist > attackRange)
            {
                Vector3 moveDir = toPlayer.normalized;
                controller.Move(moveDir * moveSpeed * Time.deltaTime);
            }

            if (dist <= attackRange)
            {
                cooldownTimer -= Time.deltaTime;
                if (cooldownTimer <= 0f)
                {
                    Attack();
                    cooldownTimer = attackCooldown;
                }
            }
        }

        private void Attack()
        {
            var health = player.GetComponent<StrikeHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
