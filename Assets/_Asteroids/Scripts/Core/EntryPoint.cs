using System;
using _Asteroids.Scripts.Core.Factory;
using _Asteroids.Scripts.Core.Input;
using _Asteroids.Scripts.Data;
using _Asteroids.Scripts.Gameplay.Ship;
using _Asteroids.Scripts.Gameplay.Spawn;
using _Asteroids.Scripts.Services;
using _Asteroids.Scripts.UI;
using _Asteroids.Scripts.UI.Statistics;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core
{
    public class EntryPoint : IInitializable, ITickable, IDisposable
    {
        private readonly StatisticsPresenter _statisticsPresenter;
        private readonly WindowGameOver _windowGameOver;
        private readonly Spawner _spawner;
        private readonly InputController _inputController;
        private readonly ShipFactory _shipFactory;
        private readonly ShipHolder _shipHolder;
        private readonly AnalyticsEventTracker _analyticsEventTracker;
        private readonly IAnalyticsService _analyticsService;
        private readonly GameplayStatisticsUpdater _gameplayStatisticsUpdater;
        private Ship _ship;
        private Laser _laser;
        
        public EntryPoint(StatisticsPresenter statisticsPresenter, WindowGameOver windowGameOver,Spawner spawner, InputController inputController,
            ShipFactory shipFactory, ShipHolder shipHolder, AnalyticsEventTracker analyticsEventTracker,
            IAnalyticsService analyticsService, GameplayStatisticsUpdater gameplayStatisticsUpdater)
        {
            _statisticsPresenter = statisticsPresenter;
            _windowGameOver = windowGameOver;
            _spawner = spawner;
            _inputController = inputController;
            _shipFactory = shipFactory;
            _shipHolder = shipHolder;
            _analyticsEventTracker = analyticsEventTracker;
            _analyticsService = analyticsService;
            _gameplayStatisticsUpdater = gameplayStatisticsUpdater;
        }

        public void Initialize()
        {
            _shipFactory.Create(Vector2.zero);
            _ship = _shipHolder.Ship.GetComponent<Ship>();
            _laser = _shipHolder.GetLaser();
            _ship.Initialize();
            _laser.Initialize();
            _spawner.Initialize();
            _inputController.Initialize();
            _statisticsPresenter.Initialize();
            _windowGameOver.Initialize();
            _analyticsEventTracker.Initialize();
            _gameplayStatisticsUpdater.Initialize();
            
            StartGame();
        }
        
        private void StartGame()
        {
            _analyticsService.LogGameStart();
            _spawner.Run();
        }

        public void Tick()
        {
            _inputController.ProcessInput();
            _statisticsPresenter.UpdateText();
        }

        public void Dispose()
        {
            _inputController.Dispose();
        }
    }
}