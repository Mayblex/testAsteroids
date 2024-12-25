using System.Threading.Tasks;

namespace _Asteroids.Scripts.Services
{
    public interface IAnalyticsService
    {
        Task Initialize();
        void LogEvent(string eventName);
        void LogEvent(string eventName, params (string Key, int Value)[] parameters);
    }
}