using _Project.CodeBase.Interfaces;
using _Project.CodeBase.Services;
using UnityEngine;

namespace _Project.CodeBase.Controllers
{
    
    public abstract class MovementController : MonoBehaviour, IResettable
    {
        [SerializeField] private GameResetService gameResetService;
        
        private Vector3 _startPosition;
        
        protected virtual void Awake() => 
            _startPosition = transform.position;

        private void Start() => 
            gameResetService.Initialize(this);

        public virtual void Reset() => 
            transform.position = _startPosition;

        public abstract void Move(Vector3 direction);
    }
}