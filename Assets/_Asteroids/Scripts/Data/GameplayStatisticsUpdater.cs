using _Asteroids.Scripts.Gameplay.Ship;

namespace _Asteroids.Scripts.Data
{
    public class GameplayStatisticsUpdater
    {
        private readonly ShipHolder _shipHolder;
        private readonly GameplayStatistics _gameplayStatistics;

        public GameplayStatisticsUpdater(ShipHolder shipHolder, GameplayStatistics gameplayStatistics)
        {
            _shipHolder = shipHolder;
            _gameplayStatistics = gameplayStatistics;
        }
        
        public void Initialize()
        {
            var ship = _shipHolder.Ship.GetComponent<Ship>();
            ship.BulletShot += OnBulletShot;
            ship.LaserShot += OnLaserShot;
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