using System.Collections.Generic;
using UnityEngine;

namespace Strike
{
    public class StrikePickupSpawner : MonoBehaviour
    {
        [SerializeField] private int maxPickups = 4;
        [SerializeField] private float interval = 8f;
        [SerializeField] private GameObject pickupPrefab;

        private float timer;
        private readonly List<GameObject> pickups = new List<GameObject>();

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                if (pickups.Count < maxPickups)
                {
                    Spawn();
                }
                timer = interval;
            }
        }

        private void Spawn()
        {
            if (pickupPrefab == null)
            {
                pickupPrefab = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                pickupPrefab.name = "Pickup";
                pickupPrefab.transform.localScale = new Vector3(0.6f, 0.2f, 0.6f);
                var renderer = pickupPrefab.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = new Color(0.2f, 0.95f, 0.8f);
                }
                pickupPrefab.AddComponent<StrikePickup>();
            }

            Vector3 pos = new Vector3(Random.Range(-8f, 8f), 0.5f, Random.Range(-8f, 8f));
            var instance = Instantiate(pickupPrefab, pos, Quaternion.identity);
            pickups.Add(instance);
        }
    }
}
