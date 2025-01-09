using _Asteroids.Scripts.Services;
using Zenject;

namespace _Asteroids.Scripts.Installers.Services
{
    public class RemoteConfigServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<IRemoteConfigService>().
                To<FirebaseRemoteConfigService>().
                AsSingle();
        }
    }
}