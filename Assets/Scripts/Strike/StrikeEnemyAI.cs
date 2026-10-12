using UnityEngine;

namespace Strike
{
    public class StrikeArenaManager : MonoBehaviour
    {
        [SerializeField] private int wallCount = 4;
        [SerializeField] private Vector3 arenaScale = new Vector3(20f, 1f, 20f);

        public void BuildArena()
        {
            EnsureGround();
            EnsureBoundaries();
            EnsurePickupZones();
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
            ground.transform.localScale = arenaScale;
            var renderer = ground.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = new Color(0.12f, 0.18f, 0.12f);
            }
        }

        private void EnsureBoundaries()
        {
            Vector3[] wallPositions =
            {
                new Vector3(0f, 2f, 20f),
                new Vector3(0f, 2f, -20f),
                new Vector3(20f, 2f, 0f),
                new Vector3(-20f, 2f, 0f)
            };

            for (int i = 0; i < wallCount; i++)
            {
                var name = "Wall_" + i;
                if (GameObject.Find(name) != null)
                {
                    continue;
                }

                var wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.name = name;
                wall.transform.position = wallPositions[i];
                wall.transform.localScale = new Vector3(40f, 4f, 1f);
                var renderer = wall.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = new Color(0.28f, 0.28f, 0.34f);
                }
            }
        }

        private void EnsurePickupZones()
        {
            if (GameObject.Find("PickupZone") != null)
            {
                return;
            }

            var zone = GameObject.CreatePrimitive(PrimitiveType.Cube);
            zone.name = "PickupZone";
            zone.transform.position = new Vector3(0f, 0.2f, 0f);
            zone.transform.localScale = new Vector3(4f, 0.2f, 4f);
            zone.GetComponent<Renderer>().material.color = new Color(0.2f, 0.9f, 0.7f, 0.5f);
            zone.AddComponent<StrikePickupSpawner>();
        }
    }
}
