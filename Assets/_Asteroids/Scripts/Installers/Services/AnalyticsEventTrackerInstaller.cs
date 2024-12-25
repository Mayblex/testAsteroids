using _Asteroids.Scripts.Services;
using Zenject;

namespace _Asteroids.Scripts.Installers.Services
{
    public class AnalyticsEventTrackerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<AnalyticsEventTracker>().
                AsSingle();
        }
    }
}