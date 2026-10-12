using UnityEngine;

namespace Strike
{
    public class StrikeProjectile : MonoBehaviour
    {
        [SerializeField] private float speed = 22f;
        [SerializeField] private float lifeTime = 3f;
        [SerializeField] private float damage = 20f;

        private void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0f)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            var health = collision.collider.GetComponent<StrikeHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
