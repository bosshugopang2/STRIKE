using UnityEngine;

namespace Strike
{
    public class StrikeArenaManager : MonoBehaviour
    {
        [SerializeField] private Vector3 arenaSize = new Vector3(20f, 1f, 20f);

        public void BuildArena()
        {
            EnsureGround();
            EnsureWalls();
            EnsurePickupZone();
        }

        private void EnsureGround()
        {
            if (GameObject.Find("Ground") != null)
            {
                return;
            }

            var ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "Ground";
            ground.transform.position = Vector3.zero;
            ground.transform.localScale = arenaSize;
            var renderer = ground.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = new Color(0.12f, 0.16f, 0.12f);
            }
        }

        private void EnsureWalls()
        {
            var wallPositions = new[]
            {
                new Vector3(0f, 2f, 20f),
                new Vector3(0f, 2f, -20f),
                new Vector3(20f, 2f, 0f),
                new Vector3(-20f, 2f, 0f)
            };

            for (int i = 0; i < wallPositions.Length; i++)
            {
                var wallName = "ArenaWall_" + i;
                if (GameObject.Find(wallName) != null)
                {
                    continue;
                }

                var wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.name = wallName;
                wall.transform.position = wallPositions[i];
                wall.transform.localScale = new Vector3(40f, 4f, 1f);
                var renderer = wall.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = new Color(0.32f, 0.32f, 0.38f);
                }
            }
        }

        private void EnsurePickupZone()
        {
            if (GameObject.Find("PickupZone") != null)
            {
                return;
            }

            var pickupZone = GameObject.CreatePrimitive(PrimitiveType.Cube);
            pickupZone.name = "PickupZone";
            pickupZone.transform.position = new Vector3(0f, 0.15f, 0f);
            pickupZone.transform.localScale = new Vector3(4f, 0.2f, 4f);
            var renderer = pickupZone.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = new Color(0.18f, 0.9f, 0.8f, 0.45f);
            }
            pickupZone.AddComponent<StrikePickupSpawner>();
        }
    }
}
