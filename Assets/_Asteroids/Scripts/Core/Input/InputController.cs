using UnityEngine.InputSystem;

namespace _Asteroids.Scripts.Core.Input
{
    public class InputController
    {
        private IInputHandler _inputHandler;
        private PlayerInput _playerInput;

        public InputController(PlayerInput playerInput,IInputHandler inputHandler)
        {
            _playerInput = playerInput;
            _inputHandler = inputHandler;
            
            _playerInput.Enable();
            
            _playerInput.Gameplay.DefaultAtack.performed += OnDefaultAtackPerformed;
            _playerInput.Gameplay.SpecialAtack.performed += OnSpecialAtackPerformed;
        }
        
        public void ProcessInput()
        {
            ReadMove();
            ReadRotation();
        }
        
        private void Dispose()
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