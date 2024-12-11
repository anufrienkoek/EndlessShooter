using UnityEngine;

namespace CodeBase.Interfaces
{
    internal interface IShooter
    {
        void Shoot(GameObject bulletPrefab, Transform pointer);
    }
}