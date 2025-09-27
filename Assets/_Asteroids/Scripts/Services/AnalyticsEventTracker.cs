using _Asteroids.Scripts.Data;
using _Asteroids.Scripts.Gameplay.Ship;

namespace _Asteroids.Scripts.Services
{
    public class AnalyticsEventTracker
    {
        private readonly IAnalyticsService _analyticsService;
        private readonly ShipHolder _shipHolder;
        private readonly GameplayStatistics _gameplayStatistics;

        public AnalyticsEventTracker(ShipHolder shipHolder, IAnalyticsService analyticsService, GameplayStatistics gameplayStatistics)
        {
            _analyticsService = analyticsService;
            _shipHolder = shipHolder;
            _gameplayStatistics = gameplayStatistics;
        }

        public void Initialize()
        {
            _shipHolder.Ship.GetComponent<Ship>().Died += OnShipDied;
            _shipHolder.Ship.GetComponent<Ship>().LaserShot += OnLaserShot;
        }

        private void OnShipDied() => _analyticsService.LogGameOver(_gameplayStatistics);

        private void OnLaserShot() => _analyticsService.LogLaserShot();
    }
}