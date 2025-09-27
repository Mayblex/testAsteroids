using _Asteroids.Scripts.Gameplay.Ship;

namespace _Asteroids.Scripts.Data
{
    public class GameplayStatisticsUpdater
    {
        private readonly ShipHolder _shipHolder;
        private readonly GameplayStatistics _gameplayStatistics;
        private Ship _ship;

        public GameplayStatisticsUpdater(ShipHolder shipHolder, GameplayStatistics gameplayStatistics)
        {
            _shipHolder = shipHolder;
            _gameplayStatistics = gameplayStatistics;
        }
        
        public void Initialize()
        {
            _ship = _shipHolder.Ship.GetComponent<Ship>();
            _ship.BulletShot += OnBulletShot;
            _ship.LaserShot += OnLaserShot;
        }

        public void Dispose()
        {
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
    }
}