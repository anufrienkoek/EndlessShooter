using _Project.CodeBase.Inputs;
using UnityEngine;

namespace _Project.CodeBase.Controllers.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementController : MovementController
    {
        [SerializeField] private float heroSpeed = 2.0f;
        [SerializeField] private float rotationForce = 2.0f;

        private PlayerInputRouter _playerInputRouter;
        private CharacterController _characterController;

        protected override void Awake()
        {
            base.Awake();
            
            _characterController = GetComponent<CharacterController>();
            _playerInputRouter = new PlayerInputRouter();
            _playerInputRouter.OnEnable();
        }

        private void Update()
        {
            Move(_playerInputRouter.GetMoveInput());
            Rotate(_playerInputRouter.GetRotateInput());
        }

        public override void Move(Vector3 direction)
        {
            direction = _characterController.transform.TransformDirection(Vector3.forward * (direction.y * Time.deltaTime));
            _characterController.Move(direction * heroSpeed);
        }

        private void Rotate(Vector3 angle)
        {
            angle = Vector3.up * angle.x;
            _characterController.transform.Rotate(angle * rotationForce);
        }

        public override void Reset()
        {
            _characterController.enabled = false;
            base.Reset();
            _characterController.enabled = true;
        }
    }
}