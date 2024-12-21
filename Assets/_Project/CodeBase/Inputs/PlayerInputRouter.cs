using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.CodeBase.Inputs
{
    public class PlayerInputRouter
    {
        private readonly PlayerInput _playerInput = new();
        public bool IsFireButtonPressed { get; private set; }
        
        public void OnEnable() => 
            _playerInput.Enable();
        
        public void Initialize()
        {
            _playerInput.Player.FirstSlotShoot.performed += OnPressFireButton;
            _playerInput.Player.FirstSlotShoot.canceled += OnReleaseFireButton;
        }

        private void OnPressFireButton(InputAction.CallbackContext obj) => 
            IsFireButtonPressed = true;

        private void OnReleaseFireButton(InputAction.CallbackContext obj) => 
            IsFireButtonPressed = false;

        public Vector2 GetMoveInput() => 
            _playerInput.Player.Move.ReadValue<Vector2>();
        
        public Vector2 GetRotateInput() => 
            _playerInput.Player.Rotate.ReadValue<Vector2>();
    }
}