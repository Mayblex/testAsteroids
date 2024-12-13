using _Asteroids.Scripts.Core.Factory;
using _Asteroids.Scripts.Core.Input;
using _Asteroids.Scripts.Gameplay.Ship;
using _Asteroids.Scripts.Gameplay.Spawn;
using _Asteroids.Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private UIStatistics _uiStatistics;
        [SerializeField] private Spawner _spawner;
        
        [Inject] private PlayerInput _playerInput;
        [Inject] private InputController _inputController;
        [Inject] private ShipFactory _shipFactory;
        private Ship _ship;
        private Laser _laser;
        private GameObject _player;
        
        private void Awake()
        {
            _player = _shipFactory.Create(Vector2.zero);
            _ship = _player.GetComponent<Ship>();
            _laser = _player.GetComponentInChildren<Laser>();
            _ship.Initialize();
            _laser.Initialize();
            _inputController.Initialize();
        }
        
        private void Start()
        {
            _ship.Construct(_laser);
            _uiStatistics.Construct(_ship, _laser);
            _uiStatistics.Run();
            _spawner.Run();
        }
        
        private void Update()
        {
            _inputController.ProcessInput();
        }
        
        private void OnDestroy()
        {
            _inputController.Dispose();
        }
    }
}