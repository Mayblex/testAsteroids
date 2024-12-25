using System.Threading.Tasks;
using Firebase;
using Firebase.Analytics;

namespace _Asteroids.Scripts.Services
{
    public class FirebaseAnalyticsService : IAnalyticsService
    {
        public async Task Initialize()
        {
            await FirebaseApp.CheckAndFixDependenciesAsync();

            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        }

        public void LogEvent(string eventName) =>
            FirebaseAnalytics.LogEvent(eventName);

        public void LogEvent(string eventName, params (string Key, int Value)[] parameters)
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