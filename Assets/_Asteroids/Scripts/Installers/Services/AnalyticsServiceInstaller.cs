using _Asteroids.Scripts.Services;
using Zenject;

namespace _Asteroids.Scripts.Installers.Services
{
    public class AnalyticsServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<IAnalyticsService>().
                To<FirebaseAnalyticsService>().
                AsSingle();
        }
    }
}