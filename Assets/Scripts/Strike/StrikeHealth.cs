using UnityEngine;

namespace Strike
{
    public class StrikeWeaponController : MonoBehaviour
    {
        [SerializeField] private float damage = 25f;
        [SerializeField] private float fireRate = 0.12f;
        [SerializeField] private float range = 50f;
        [SerializeField] private int clipSize = 30;
        [SerializeField] private int currentAmmo = 30;
        [SerializeField] private float reloadTime = 1.2f;

        private float nextFireTime;
        private float reloadTimer;
        private Camera playerCamera;
        private Transform weaponOrigin;
        private bool isReloading;

        private void Update()
        {
            if (playerCamera == null)
            {
                playerCamera = Camera.main;
            }

            if (StrikeInputManager.FirePressed() && Time.time >= nextFireTime)
            {
                Fire();
            }

            if (currentAmmo <= 0 && !isReloading)
            {
                StartReload();
            }

            if (isReloading)
            {
                reloadTimer -= Time.deltaTime;
                if (reloadTimer <= 0f)
                {
                    FinishReload();
                }
            }
        }

        public void SetWeaponOrigin(Transform origin)
        {
            weaponOrigin = origin;
        }

        private void Fire()
        {
            if (isReloading || currentAmmo <= 0)
            {
                return;
            }

            currentAmmo--;
            nextFireTime = Time.time + fireRate;

            Vector3 rayOrigin = playerCamera != null ? playerCamera.transform.position : transform.position;
            Vector3 rayDirection = playerCamera != null ? playerCamera.transform.forward : transform.forward;

            if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hit, range))
            {
                var target = hit.collider.GetComponent<StrikeTargetDummy>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
                else
                {
                    var health = hit.collider.GetComponent<StrikeHealth>();
                    if (health != null)
                    {
                        health.TakeDamage(damage);
                    }
                }
            }
        }

        private void StartReload()
        {
            isReloading = true;
            reloadTimer = reloadTime;
        }

        private void FinishReload()
        {
            currentAmmo = clipSize;
            isReloading = false;
        }
    }
}
