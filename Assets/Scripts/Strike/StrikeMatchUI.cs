using UnityEngine;

namespace Strike
{
    public class StrikePickup : MonoBehaviour
    {
        [SerializeField] private float healAmount = 25f;

        private void OnTriggerEnter(Collider other)
        {
            var health = other.GetComponent<StrikeHealth>();
            if (health != null)
            {
                health.Heal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
