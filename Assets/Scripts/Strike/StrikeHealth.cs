using UnityEngine;

namespace Strike
{
    public class StrikeWeaponController : MonoBehaviour
    {
        [SerializeField] private float damage = 25f;
        [SerializeField] private float fireRate = 0.12f;
        [SerializeField] private float range = 60f;
        [SerializeField] private int clipSize = 30;
        [SerializeField] private int ammo = 30;
        [SerializeField] private float reloadTime = 1.2f;

        private float nextShotTime;
        private float reloadTimer;
        private bool reloadActive;
        private Camera currentCamera;

        private void Update()
        {
            if (currentCamera == null)
            {
                currentCamera = Camera.main;
            }

            if (StrikeInputManager.FirePressed() && Time.time >= nextShotTime)
            {
                TryFire();
            }

            if (ammo <= 0 && !reloadActive)
            {
                BeginReload();
            }

            if (reloadActive)
            {
                reloadTimer -= Time.deltaTime;
                if (reloadTimer <= 0f)
                {
                    CompleteReload();
                }
            }
        }

        public void TryFire()
        {
            if (reloadActive || ammo <= 0)
            {
                return;
            }

            ammo--;
            nextShotTime = Time.time + fireRate;

            Vector3 origin = currentCamera != null ? currentCamera.transform.position : transform.position;
            Vector3 dir = currentCamera != null ? currentCamera.transform.forward : transform.forward;

            if (Physics.Raycast(origin, dir, out RaycastHit hit, range))
            {
                var enemy = hit.collider.GetComponent<StrikeEnemyAI>();
                if (enemy != null)
                {
                    var health = hit.collider.GetComponent<StrikeHealth>();
                    if (health != null)
                    {
                        health.TakeDamage(damage);
                    }
                }
            }
        }

        public void BeginReload()
        {
            reloadActive = true;
            reloadTimer = reloadTime;
        }

        public void CompleteReload()
        {
            ammo = clipSize;
            reloadActive = false;
        }

        public string AmmoText => ammo + "/" + clipSize;
    }
}
