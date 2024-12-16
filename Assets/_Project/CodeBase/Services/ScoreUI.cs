using _Project.CodeBase.Controllers;
using TMPro;
using UnityEngine;

namespace _Project.CodeBase.Services
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private Damageable playerShooter;
        [SerializeField] private Damageable botShooter;
        
        private int _playerScore => playerShooter.Dies;
        private int _botScore => botShooter.Dies;
        
        public void UpdateScore() => 
            scoreText.SetText($"score: {_botScore}:{_playerScore}");
    }
}
