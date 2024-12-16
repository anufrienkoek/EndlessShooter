using _Project.CodeBase.Interfaces;
using UnityEngine;

namespace _Project.CodeBase.Controllers
{
    
    public abstract class MovementController : MonoBehaviour, IMovable, IResettable
    {
        private Vector3 _startPosition;

        protected virtual void Awake() => 
            _startPosition = transform.position;

        public virtual void ResetPosition() => 
            transform.position = _startPosition;

        public abstract void Move(Vector3 direction);
        public abstract void Rotate(Vector3 direction);
    }
}