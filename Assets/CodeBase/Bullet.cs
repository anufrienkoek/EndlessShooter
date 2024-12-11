using CodeBase.Controllers;
using CodeBase.Services;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase
{
    public class Bullet : MonoBehaviour
    {
        private GameManager _gameManager;
        private ScoreUI _score;
        
        private readonly CollisionService _collisionService = new();

        private void OnEnable()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _score = FindObjectOfType<ScoreUI>();
        }

        public void OnCollisionEnter(Collision other)
        {
            _collisionService.HandleCollision(other.gameObject);

            if (other.gameObject.GetComponent<PlayerShooter>())
            {
                other.gameObject.GetComponent<PlayerShooter>().kills++;
                _gameManager.ResetAll();
            }
            else if (other.gameObject.GetComponent<BotShooter>())
            {
                other.gameObject.GetComponent<BotShooter>().kills++;
                _gameManager.ResetAll();
            }
            
            _score.UpdateScore();
        }
    }
}