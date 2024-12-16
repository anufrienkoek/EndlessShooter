using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.CodeBase.Inputs
{
    public class PlayerInputRouter
    {
        private readonly PlayerInput _playerInput = new();
        private bool _fireButtonPressed;

        public void OnEnable() => 
            _playerInput.Enable();
        
        public void Initialize()
        {
            _playerInput.Player.FirstSlotShoot.performed += OnPressFireButton;
            _playerInput.Player.FirstSlotShoot.canceled += OnReleaseFireButton;
        }

        private void OnPressFireButton(InputAction.CallbackContext obj)
        {
            Debug.Log("Ok");
            _fireButtonPressed = true;
        }

        private void OnReleaseFireButton(InputAction.CallbackContext obj)
        {
            Debug.Log("dontok");
            _fireButtonPressed = false;
        }

        public bool IsFireButtonPressed() => 
            _fireButtonPressed;

        public Vector2 GetMoveInput() => 
            _playerInput.Player.Move.ReadValue<Vector2>();
        
        public Vector2 GetRotateInput() => 
            _playerInput.Player.Rotate.ReadValue<Vector2>();
        
        
    }
}