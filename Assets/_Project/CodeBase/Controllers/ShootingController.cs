using _Project.CodeBase.Core;
using UnityEngine;

namespace _Project.CodeBase.Controllers
{
    public abstract class ShootingController : MonoBehaviour
    {
        [SerializeField] protected BulletPool bulletPool;
        [SerializeField] protected Transform pointer;
        [SerializeField] protected float bulletForce;
        
        protected const float ShootCooldown = 1f;
        protected float TimeSinceLastShot;

        protected virtual void Update()
        {
            TimeSinceLastShot += Time.deltaTime;

            TryShoot();
        }

        private void TryShoot()
        {
            if (CanShoot())
            {
                Shoot();
                TimeSinceLastShot = 0;
            }
        }

        private void Shoot()
        {
            Bullet bullet = bulletPool.GetBullet();

            if (bullet == null)
                return;

            if (bullet.TryGetComponent<Bullet>(out var newBullet)) 
                newBullet.Initialize(pointer.position, pointer.rotation, pointer.forward * bulletForce);
        }

        protected abstract bool CanShoot();
    }
}