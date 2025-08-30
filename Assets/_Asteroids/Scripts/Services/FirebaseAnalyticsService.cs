using _Asteroids.Scripts.Data;
using Cysharp.Threading.Tasks;
using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using static _Asteroids.Scripts.Services.AnalyticsEventName;

namespace _Asteroids.Scripts.Services
{
    public class FirebaseAnalyticsService : IAnalyticsService
    {
        private readonly GameplayStatistics _gameplayStatistics;

        FirebaseAnalyticsService(GameplayStatistics gameplayStatistics)
        {
            _gameplayStatistics = gameplayStatistics;
        }
        
        public async UniTask Initialize()
        {
            await FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {
                FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                var app = FirebaseApp.DefaultInstance;
            });
        }

        public void LogGameStart()
        {
            FirebaseAnalytics.LogEvent(GAME_START);
        }

        public void LogGameOver()
        {
            LogEvent(GAME_OVER,
                (BULLET_SHOT, _gameplayStatistics.BulletShots),
                (LASER_SHOTS, _gameplayStatistics.LaserShots),
                (DESTROYED_ASTEROIDS, _gameplayStatistics.DestroyedAsteroids),
                (DESTROYED_UFOS, _gameplayStatistics.DestroyedUFOs)
            );
        }

        public void LogLaserShot()
        {
            FirebaseAnalytics.LogEvent(LASER_SHOTS);
        }

        private void LogEvent(string eventName, params (string Key, int Value)[] parameters)
        {
            var firebaseParameters = new Parameter[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                firebaseParameters[i] = new Parameter(parameters[i].Key, parameters[i].Value.ToString());
            }

            FirebaseAnalytics.LogEvent(eventName, firebaseParameters);
        }
    }
}