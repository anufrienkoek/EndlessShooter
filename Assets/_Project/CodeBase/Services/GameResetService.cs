using System.Collections.Generic;
using System.Linq;
using _Project.CodeBase.Core;
using _Project.CodeBase.Interfaces;
using UnityEngine;

namespace _Project.CodeBase.Services
{
    public class GameResetService : MonoBehaviour
    {
        public static GameResetService Instance { get; set; }

        private List<IResettable> _resettables;
        [SerializeField] private BulletPool playerBullets;
        [SerializeField] private BulletPool enemyBullets;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                _resettables = new List<IResettable>();

                foreach (var resettable in FindObjectsOfType<MonoBehaviour>().OfType<IResettable>())
                    RegisterResettable(resettable);

                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        private void RegisterResettable(IResettable resettable)
        {
            if (_resettables.Contains(resettable) == false)
                _resettables.Add(resettable);
        }

        public void ResetAll()
        {
            foreach (var resettable in _resettables)
                resettable.ResetPosition();

            playerBullets.ReturnAllBullets();
            enemyBullets.ReturnAllBullets();
        }

        public void ReturnAllBullets()
        {
            playerBullets.ReturnAllBullets();
            enemyBullets.ReturnAllBullets();
        }
    }
}
