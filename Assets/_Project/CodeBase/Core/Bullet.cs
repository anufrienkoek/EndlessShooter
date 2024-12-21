using _Project.CodeBase.Controllers;
using _Project.CodeBase.Interfaces;
using UnityEngine;

namespace _Project.CodeBase.Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour, IResettable
    {
        private const float LifeTime = 3f;
        
        private Rigidbody _rigidbody;
        private float _timer;

        public BulletPool BulletPool { get; set; }
        
        private void Awake() => 
            _rigidbody = GetComponent<Rigidbody>();

        public void Initialize(Vector3 position, Quaternion rotation, Vector3 force)
        {
            transform.position = position;
            transform.rotation = rotation;

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }
        
        private void OnEnable() =>
            _timer = 0f;

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= LifeTime)
                Reset();
        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.TryGetComponent<ExitArea>(out var exitArea))
                Reset();
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Damageable>(out var damageable)) 
                Reset();
        }

        public void Reset() => 
            BulletPool.ReturnBullet(this);
    }
}

