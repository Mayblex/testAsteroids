using _Asteroids.Scripts.Data;
using _Asteroids.Scripts.Gameplay.Ship;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Asteroids.Scripts.Gameplay.Statistics
{
    public class GameplayStatisticsUpdater
    {
        private readonly ShipHolder _shipHolder;
        private readonly GameplayStatistics _gameplayStatistics;
        
        private Ship.Ship _ship;
        private bool _running;

        public GameplayStatisticsUpdater(ShipHolder shipHolder, GameplayStatistics gameplayStatistics)
        {
            _shipHolder = shipHolder;
            _gameplayStatistics = gameplayStatistics;
        }
        
        public void Initialize()
        {
            _ship = _shipHolder.Ship;
            _ship.BulletShot += OnBulletShot;
            _ship.LaserShot += OnLaserShot;
            
            _running = true;
            TimerLoop().Forget();
        }

        public void Dispose()
        {
            _running = false;
            
            _ship.BulletShot -= OnBulletShot;
            _ship.LaserShot -= OnLaserShot;
        }

        private void OnBulletShot()
        {
            _gameplayStatistics.IncrementBulletShots();
        }

        private void OnLaserShot()
        {
            _gameplayStatistics.IncrementLaserShots();
        }

        private async UniTask TimerLoop()
        {
            while (_running)
            {
                await UniTask.Yield(PlayerLoopTiming.Update);
                
                _gameplayStatistics.AddPlayTime(Time.deltaTime);
            }
        }
    }
}