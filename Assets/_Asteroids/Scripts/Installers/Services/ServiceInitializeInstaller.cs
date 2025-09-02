using _Asteroids.Scripts.Services;
using Zenject;

namespace _Asteroids.Scripts.Installers.Services
{
    public class ServiceInitializeInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<IServiceInitialize>().
                To<FirebaseInitialize>().
                AsSingle();
        }
    }
}