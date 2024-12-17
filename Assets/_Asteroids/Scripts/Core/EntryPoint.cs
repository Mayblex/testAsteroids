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
        private UIStatistics _uiStatistics;
        private Spawner _spawner;
        private InputController _inputController;
        private ShipFactory _shipFactory;
        private ShipHolder _shipHolder;
        private Ship _ship;
        private Laser _laser;
        
        [Inject]
        public void Construct(UIStatistics uiStatistics, Spawner spawner, InputController inputController,
            ShipFactory shipFactory, ShipHolder shipHolder)
        {
            _uiStatistics = uiStatistics;
            _spawner = spawner;
            _inputController = inputController;
            _shipFactory = shipFactory;
            _shipHolder = shipHolder;
        }
        
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