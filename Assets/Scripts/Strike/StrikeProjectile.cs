using UnityEngine;

namespace Strike
{
    public class StrikeTargetDummy : MonoBehaviour
    {
        [SerializeField] private float health = 50f;

        public void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
