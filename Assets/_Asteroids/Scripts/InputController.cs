using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    [RequireComponent(typeof(IInputHandler))]

    public class InputController : MonoBehaviour
    {
        private IInputHandler _inputHandler;
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();
            
            _inputHandler = GetComponent<IInputHandler>();
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