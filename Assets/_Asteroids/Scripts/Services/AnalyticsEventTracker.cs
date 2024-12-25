namespace _Asteroids.Scripts.Services
{
    public class AnalyticsEventTracker
    {
        private readonly IAnalyticsService _analyticsService;
        private GameplayStatistics _gameplayStatistics;
        
        public AnalyticsEventTracker(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
            _gameplayStatistics = new GameplayStatistics();
        }
        
        public void LogStartGameEvent() =>
            _analyticsService.LogEvent(AnalyticsEventName.GAME_START);
        
        public void LogEndGameEvent(GameplayStatistics gameplayStatistics)
        {
            _analyticsService.LogEvent(AnalyticsEventName.GAME_OVER,
                (AnalyticsEventName.BULLET_SHOT, gameplayStatistics.BulletShots),
                (AnalyticsEventName.LASER_SHOTS, gameplayStatistics.LaserShots),
                (AnalyticsEventName.DESTROYED_ASTEROIDS, gameplayStatistics.DestroyedAsteroids),
                (AnalyticsEventName.DESTROYED_UFOS, gameplayStatistics.DestroyedUFOs)
            );
        }
        
        public void LogLaserShot() =>
            _analyticsService.LogEvent(AnalyticsEventName.LASER_SHOTS);
    }
}