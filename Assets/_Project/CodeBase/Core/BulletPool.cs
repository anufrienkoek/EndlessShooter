using System.Collections.Generic;
using System.Linq;
using _Project.CodeBase.Interfaces;
using _Project.CodeBase.Services;
using UnityEngine;

namespace _Project.CodeBase.Core
{
    public class BulletPool : MonoBehaviour, IResettable
    {
        [SerializeField] private GameResetService gameResetService;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private int poolSize = 10;

        private Queue<Bullet> _bulletPool;
        private List<Bullet> _activeBullets;

        private void Awake()
        {
            _bulletPool = new Queue<Bullet>();
            _activeBullets = new List<Bullet>();
        }

        private void Start()
        {
            for (int i = 0; i < poolSize; i++)
            {
                Bullet bullet = Instantiate(bulletPrefab);
                bullet.gameObject.SetActive(false);
                bullet.BulletPool = this;
                
                _bulletPool.Enqueue(bullet);
            }
            
            gameResetService.Initialize(this);
        }

        public Bullet GetBullet()
        {
            if (_bulletPool.Count > 0)
            {
                Bullet bullet = _bulletPool.Dequeue();
                bullet.gameObject.SetActive(true);
                _activeBullets.Add(bullet);
                
                return bullet;
            }

            return null;
        }

        public void ReturnBullet(Bullet bullet)
        {
            if (_activeBullets.Contains(bullet))
            {
                bullet.transform.rotation = Quaternion.identity;
                bullet.gameObject.SetActive(false);
                
                _bulletPool.Enqueue(bullet);
                _activeBullets.Remove(bullet);
            }
        }

        public void Reset()
        {
            foreach (var bullet in _activeBullets.ToList()) 
                ReturnBullet(bullet);
        }
    }
}