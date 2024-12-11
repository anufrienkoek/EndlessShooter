using CodeBase.Controllers;
using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private PlayerShooter playerShooter;
        [SerializeField] private BotShooter botShooter;
        
        private int _playerScore => playerShooter.kills;
        private int _botScore => botShooter.kills;
        
        
        public void UpdateScore() => 
            scoreText.SetText($"score: {_playerScore}:{_botScore}");
    }
}
