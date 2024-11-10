using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class InputController : MonoBehaviour
    {
        private IInput _input;
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();
            
            _input = GetComponent<IInput>();

            if (_input == null)
            {
                throw new Exception($"There is no IInput component on the object: {gameObject.name}");
            }
        }

        private void Update()
        {
            ReadMove();
            ReadRotation();
        }

        private void OnEnable()
        {
            _playerInput.Gameplay.DefaultAtack.performed += OnDefaultAtackPerformed;
            _playerInput.Gameplay.SpecialAtack.performed += OnSpecialAtackPerformed;
        }

        private void OnDisable()
        {
            _playerInput.Gameplay.DefaultAtack.performed -= OnDefaultAtackPerformed;
            _playerInput.Gameplay.SpecialAtack.performed -= OnSpecialAtackPerformed;
        }

        private void OnDefaultAtackPerformed(InputAction.CallbackContext obj)
        {
            _input.DefaultAtack();
        }

        private void OnSpecialAtackPerformed(InputAction.CallbackContext obj)
        {
            
        }

        private void ReadMove()
        {
            var position = _playerInput.Gameplay.MoveForward.ReadValue<float>();
            _input.MoveForward(position);
        }

        private void ReadRotation()
        {
            var rotation = _playerInput.Gameplay.Turn.ReadValue<float>();
            _input.Turn(rotation);
        }
    }
}