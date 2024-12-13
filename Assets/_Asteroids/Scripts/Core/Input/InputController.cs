using _Asteroids.Scripts.Gameplay.Ship;
using UnityEngine.InputSystem;

namespace _Asteroids.Scripts.Core.Input
{
    public class InputController
    {
        private readonly PlayerInput _playerInput;
        private readonly ShipHolder _shipHolder;
        private IInputHandler _inputHandler;
        
        public InputController(PlayerInput playerInput, ShipHolder shipHolder)
        {
            _playerInput = playerInput;
            _shipHolder = shipHolder;
            
            _playerInput.Enable();
            
            _playerInput.Gameplay.DefaultAtack.performed += OnDefaultAtackPerformed;
            _playerInput.Gameplay.SpecialAtack.performed += OnSpecialAtackPerformed;
        }

        public void Initialize()
        {
            _inputHandler = _shipHolder.GetInputHandler();
        }

        public void ProcessInput()
        {
            ReadMove();
            ReadRotation();
        }

        public void Dispose()
        {
            _playerInput.Gameplay.DefaultAtack.performed -= OnDefaultAtackPerformed;
            _playerInput.Gameplay.SpecialAtack.performed -= OnSpecialAtackPerformed;
        }

        private void OnDefaultAtackPerformed(InputAction.CallbackContext obj)
        {
            _inputHandler.DefaultAtack();
        }
        
        private void OnSpecialAtackPerformed(InputAction.CallbackContext obj)
        {
            _inputHandler.SpecialAtack();
        }

        private void ReadMove()
        {
            var input = _playerInput.Gameplay.MoveForward.ReadValue<float>();
            _inputHandler.MoveForward(input);
        }

        private void ReadRotation()
        {
            var input = _playerInput.Gameplay.Turn.ReadValue<float>();
            _inputHandler.Turn(input);
        }
    }
}