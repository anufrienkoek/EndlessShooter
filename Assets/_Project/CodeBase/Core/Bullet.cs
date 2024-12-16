using _Project.CodeBase.Controllers;
using _Project.CodeBase.Services;
using UnityEngine;

namespace _Project.CodeBase.Core
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 3f;

        private float timer;

        private void OnEnable() =>
            timer = 0f;

        private void Update()
        {
            timer += Time.deltaTime;

            if (timer >= lifeTime)
                ReturnToPool();
        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.GetComponent<ExitArea>())
                ReturnToPool();
        }

        private void ReturnToPool() =>
            FindObjectOfType<BulletPool>().ReturnBullet(gameObject);


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Damageable>(out var damageable))
            {
                GameResetService.Instance.ReturnAllBullets();
            }
        }
    }
}

