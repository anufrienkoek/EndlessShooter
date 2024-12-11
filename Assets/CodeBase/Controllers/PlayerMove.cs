using CodeBase.Interfaces;
using UnityEngine;

namespace CodeBase.Controllers
{
    public class PlayerMove : MonoBehaviour, IMovable, IResettable
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float heroSpeed = 2.0f;
        [SerializeField] private float rotationForce = 2.0f;
        
        private Vector3 _startPosition;
        private float _vertical;
        private float _horizontal;
        
        private void Start() =>
            _startPosition = transform.position;

        private void Update()
        {
            _vertical = Input.GetAxis("Vertical");
            _horizontal = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            Move(Vector3.forward * (_vertical * (Time.deltaTime * heroSpeed)));
            Rotate(Vector3.up * (_horizontal * rotationForce));
        }

        public void Move(Vector3 direction) =>
            characterController.Move(characterController.transform.TransformDirection(direction));

        public void Rotate(Vector3 angle) =>
            characterController.transform.Rotate(angle);

        public void ResetPosition()
        {
            characterController.enabled = false;
            transform.position = _startPosition;
            characterController.enabled = true;
        }
    }
}