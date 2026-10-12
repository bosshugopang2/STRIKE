using System.Collections.Generic;
using UnityEngine;

namespace Strike
{
    public class StrikePickupSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject pickupPrefab;
        [SerializeField] private int maxPickups = 5;
        [SerializeField] private float spawnInterval = 6f;

        private readonly List<GameObject> spawnedPickups = new List<GameObject>();
        private float timer;

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                if (spawnedPickups.Count < maxPickups)
                {
                    SpawnPickup();
                }
                timer = spawnInterval;
            }
        }

        private void SpawnPickup()
        {
            if (pickupPrefab == null)
            {
                pickupPrefab = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                pickupPrefab.name = "HealthPickup";
                pickupPrefab.transform.localScale = new Vector3(0.6f, 0.2f, 0.6f);
                var renderer = pickupPrefab.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = new Color(0.25f, 0.95f, 0.85f);
                }
                pickupPrefab.AddComponent<StrikePickup>();
            }

            Vector3 pos = new Vector3(Random.Range(-8f, 8f), 0.6f, Random.Range(-8f, 8f));
            var instance = Instantiate(pickupPrefab, pos, Quaternion.identity);
            spawnedPickups.Add(instance);
        }
    }
}
