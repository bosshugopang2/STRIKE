using UnityEngine;

namespace Strike
{
    public class StrikeHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float currentHealth = 100f;

        public float CurrentHealth => currentHealth;
        public float MaxHealth => maxHealth;

        public void SetMaxHealth(float value)
        {
            maxHealth = value;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        }

        public void TakeDamage(float amount)
        {
            currentHealth = Mathf.Max(0f, currentHealth - amount);

            if (currentHealth <= 0f && gameObject.CompareTag("Player"))
            {
                var manager = FindObjectOfType<StrikeGameManager>();
                if (manager != null)
                {
                    manager.RegisterPlayerDeath();
                }
            }
        }

        public void Heal(float amount)
        {
            currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
        }
    }
}
