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
        [Inject] private UIStatistics _uiStatistics;
        [Inject] private Spawner _spawner;
        [Inject] private PlayerInput _playerInput;
        [Inject] private InputController _inputController;
        [Inject] private ShipFactory _shipFactory;
        [Inject] private ShipHolder _shipHolder;
        private Ship _ship;
        private Laser _laser;
        
        private void Awake()
        {
            _shipFactory.Create(Vector2.zero);
            _ship = _shipHolder.Ship.GetComponent<Ship>();
            _laser = _shipHolder.GetLaser();
            _ship.Initialize();
            _laser.Initialize();
            _inputController.Initialize();
            _uiStatistics.Initialize();
        }
        
        private void Start()
        {
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