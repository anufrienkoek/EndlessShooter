using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.CodeBase.Core
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private int poolSize = 10;

        private Queue<GameObject> bulletPool;
        private List<GameObject> activeBullets;

        private void Awake()
        {
            bulletPool = new Queue<GameObject>();
            activeBullets = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.SetActive(false);
                bulletPool.Enqueue(bullet);
            }
        }

        public GameObject GetBullet()
        {
            if (bulletPool.Count > 0)
            {
                GameObject bullet = bulletPool.Dequeue();
                bullet.SetActive(true);
                activeBullets.Add(bullet);
                return bullet;
            }

            return null;
        }

        public void ReturnBullet(GameObject bullet)
        {
            if (activeBullets.Contains(bullet))
            {
                bullet.SetActive(false);
                bulletPool.Enqueue(bullet);
                activeBullets.Remove(bullet);
            }
        }

        public void ReturnAllBullets()
        {
            foreach (var bullet in activeBullets.ToList())
            {
                ReturnBullet(bullet);
            }
        }
    }
}