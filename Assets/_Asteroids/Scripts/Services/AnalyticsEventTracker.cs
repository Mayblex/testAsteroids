using _Asteroids.Scripts.Data;
using _Asteroids.Scripts.Gameplay.Ship;

namespace _Asteroids.Scripts.Services
{
    public class AnalyticsEventTracker
    {
        private readonly IAnalyticsService _analyticsService;
        private readonly GameplayStatistics _gameplayStatistics;
        private readonly ShipHolder _shipHolder;

        public AnalyticsEventTracker(ShipHolder shipHolder, IAnalyticsService analyticsService, GameplayStatistics gameplayStatistics)
        {
            _analyticsService = analyticsService;
            _gameplayStatistics = gameplayStatistics;
            _shipHolder = shipHolder;
        }

        public void Initialize()
        {
            _shipHolder.Ship.GetComponent<Ship>().Died += OnShipDied;
            _shipHolder.Ship.GetComponent<Ship>().LaserShot += OnLaserShot;
        }

        public void LogStartGameEvent() =>
            _analyticsService.LogEvent(AnalyticsEventName.GAME_START);

        private void LogEndGameEvent()
        {
            _analyticsService.LogEvent(AnalyticsEventName.GAME_OVER,
                (AnalyticsEventName.BULLET_SHOT, _gameplayStatistics.BulletShots),
                (AnalyticsEventName.LASER_SHOTS, _gameplayStatistics.LaserShots),
                (AnalyticsEventName.DESTROYED_ASTEROIDS, _gameplayStatistics.DestroyedAsteroids),
                (AnalyticsEventName.DESTROYED_UFOS, _gameplayStatistics.DestroyedUFOs)
            );
        }

        private void LogLaserShot() =>
            _analyticsService.LogEvent(AnalyticsEventName.LASER_SHOTS);

        private void OnShipDied() => LogEndGameEvent();

        private void OnLaserShot() => LogLaserShot();
    }
}