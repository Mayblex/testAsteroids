using _Asteroids.Scripts.Services;
using _Asteroids.Scripts.Services.SceneLoading;
using Zenject;

namespace _Asteroids.Scripts.Installers.Services
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<ISceneLoader>().
                To<SceneLoader>().
                AsSingle();
        }
    }
}