using UnityEngine;

namespace Strike
{
    public class StrikeHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float currentHealth = 100f;

        public delegate void HealthChanged(float current, float max);
        public event HealthChanged OnHealthChanged;

        public delegate void Died(GameObject source);
        public event Died OnDeath;

        private void Start()
        {
            currentHealth = maxHealth;
            NotifyHealthChanged();
        }

        public void SetMaxHealth(float value)
        {
            maxHealth = value;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
            NotifyHealthChanged();
        }

        public void TakeDamage(float amount)
        {
            if (currentHealth <= 0f)
            {
                return;
            }

            currentHealth = Mathf.Max(0f, currentHealth - amount);
            NotifyHealthChanged();

            if (currentHealth <= 0f)
            {
                Die();
            }
        }

        public void Heal(float amount)
        {
            currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
            NotifyHealthChanged();
        }

        public float CurrentHealth => currentHealth;
        public float MaxHealth => maxHealth;

        private void Die()
        {
            OnDeath?.Invoke(gameObject);

            if (gameObject.CompareTag("Player"))
            {
                var manager = FindObjectOfType<StrikeGameManager>();
                if (manager != null)
                {
                    manager.RegisterPlayerDeath();
                }
            }
        }

        private void NotifyHealthChanged()
        {
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }
    }
}
