using _Project.CodeBase.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.CodeBase.Controllers
{
    public abstract class ShootingController : MonoBehaviour
    {
        [FormerlySerializedAs("objectPool")] [SerializeField] protected BulletPool bulletPool;
        [SerializeField] protected Transform pointer;
        [SerializeField] protected GameObject bulletPrefab;
        [SerializeField] protected float bulletForce;
        
        protected const float DelayBeforeShoot = 1f;
        protected float CurrentTime;

        protected virtual void Update() => 
            CurrentTime += Time.deltaTime;
        
        protected void Shoot()
        {
            GameObject bullet = bulletPool.GetBullet();

            if (bullet != null)
            {
                bullet.transform.position = pointer.position;
                bullet.transform.rotation = pointer.rotation;

                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = Vector3.zero;
                    bulletRigidbody.angularVelocity = Vector3.zero;
                    bulletRigidbody.AddForce(pointer.forward * bulletForce, ForceMode.Impulse);
                }
                else
                {
                    Debug.LogError("Bullet prefab does not have a Rigidbody component!");
                }
            }
        }

        protected abstract bool CanShoot();
    }
}