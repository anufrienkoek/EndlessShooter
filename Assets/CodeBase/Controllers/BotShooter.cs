using CodeBase.Interfaces;
using UnityEngine;

namespace CodeBase.Controllers
{
    public class BotShooter : MonoBehaviour, IShooter
    {
        [SerializeField] private BotMove botMoveController;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform pointer;
        [SerializeField] private float bulletForce;

        public int kills;
        
        private const float DelayBeforeShoot = 0.26f;
        private float _currentTime;
        

        private void FixedUpdate()
        {
            _currentTime += Time.fixedDeltaTime;
            
            if (botMoveController.IsPlayerInSight() && _currentTime >= DelayBeforeShoot)
            {
                _currentTime = 0;
                Shoot(bulletPrefab,pointer);
            }
        }

        public void Shoot(GameObject bulletPrefab, Transform pointerPosition)
        {
            var newBullet = Instantiate(bulletPrefab, pointer.position, pointer.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward * bulletForce),ForceMode.Impulse);
        }
    }
}