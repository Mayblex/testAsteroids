using System;
using _Asteroids.Scripts.Core.Factory;
using _Asteroids.Scripts.Core.Input;
using _Asteroids.Scripts.Gameplay.Ship;
using _Asteroids.Scripts.Gameplay.Spawn;
using _Asteroids.Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core
{
    public class EntryPoint : IInitializable, ITickable, IDisposable
    {
        private readonly UIStatistics _uiStatistics;
        private readonly Spawner _spawner;
        private readonly InputController _inputController;
        private readonly ShipFactory _shipFactory;
        private readonly ShipHolder _shipHolder;
        private Ship _ship;
        private Laser _laser;
        
        public EntryPoint(UIStatistics uiStatistics, Spawner spawner, InputController inputController,
            ShipFactory shipFactory, ShipHolder shipHolder)
        {
            _uiStatistics = uiStatistics;
            _spawner = spawner;
            _inputController = inputController;
            _shipFactory = shipFactory;
            _shipHolder = shipHolder;
        }

        public void Initialize()
        {
            _shipFactory.Create(Vector2.zero);
            _ship = _shipHolder.Ship.GetComponent<Ship>();
            _laser = _shipHolder.GetLaser();
            _ship.Initialize();
            _laser.Initialize();
            _inputController.Initialize();
            _uiStatistics.Initialize();
            
            StartGame();
        }
        
        private void StartGame()
        {
            _uiStatistics.Run();
            _spawner.Run();
        }

        public void Tick()
        {
            _inputController.ProcessInput();
        }

        public void Dispose()
        {
            _inputController.Dispose();
        }
    }
}