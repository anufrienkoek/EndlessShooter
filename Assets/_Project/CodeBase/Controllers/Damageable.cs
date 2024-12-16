using _Project.CodeBase.Core;
using _Project.CodeBase.Services;
using UnityEngine;

namespace _Project.CodeBase.Controllers
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField] private GameResetService _gameResetService;
        [SerializeField] private ScoreUI _score;

        public int Dies { get; private set; }

        private void OnCollisionEnter(Collision other)
        {
            var collidedObject = other.gameObject;

            if (collidedObject.GetComponent<Bullet>())
            {
                _gameResetService?.ResetAll();
                Dies++;
                _score?.UpdateScore();
            }
        }
    }
}