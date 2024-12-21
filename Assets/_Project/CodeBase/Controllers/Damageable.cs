using _Project.CodeBase.Core;
using _Project.CodeBase.Services;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.CodeBase.Controllers
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField] private GameResetService gameResetService;
        [SerializeField] private ScoreUI score;

        public int Dies { get; private set; }

        private void OnCollisionEnter(Collision other)
        {
            var collidedObject = other.gameObject;

            if (collidedObject.TryGetComponent<Bullet>(out var bullet))
            {
                gameResetService?.Reset();
                Dies++;
                score?.UpdateScore();
            }
        }
    }
}