using _Asteroids.Scripts.Data;
using Cysharp.Threading.Tasks;

namespace _Asteroids.Scripts.Services.Analytics
{
    public interface IAnalyticsService
    {
        UniTask Initialize();
        void LogGameStart();
        void LogGameOver(GameplayStatistics statistics);
        void LogLaserShot();
    }
}