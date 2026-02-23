using _Asteroids.Scripts.Data;
using _Asteroids.Scripts.Services;
using Zenject;

namespace _Asteroids.Scripts.Installers.Services
{
    public class SaveServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<ISaveService>().
                To<PlayerPrefsSaveService>().
                AsSingle();

            Container.
                Bind<SaveData>().
                FromMethod(ctx => ctx.Container.Resolve<ISaveService>().Load()).
                AsSingle();
        }
    }
}