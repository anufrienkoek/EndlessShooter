using CodeBase.Interfaces;
using UnityEngine;

namespace CodeBase.Services
{
    public class CollisionService
    {
        private GameResetService _gameResetService = new GameResetService();

        public void HandleCollision(GameObject collided)
        {
            var damageable = collided.GetComponent<IDamageable>();

            if(damageable != null) 
                damageable.TakeDamage(1);
        }
    }
}