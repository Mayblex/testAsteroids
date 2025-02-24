using System.Threading.Tasks;

namespace _Asteroids.Scripts.Services
{
    public interface IAnalyticsService
    {
        Task Initialize();
        void LogGameStart();
        void LogGameOver();
        void LogLaserShot();
    }
}