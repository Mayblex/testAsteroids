using Cysharp.Threading.Tasks;

namespace _Asteroids.Scripts.Services
{
    public interface IAnalyticsService
    {
        UniTask Initialize();
        void LogGameStart();
        void LogGameOver();
        void LogLaserShot();
    }
}