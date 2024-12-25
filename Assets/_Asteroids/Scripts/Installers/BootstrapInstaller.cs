using _Asteroids.Scripts.Core;
using Zenject;

namespace _Asteroids.Scripts.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                BindInterfacesAndSelfTo<Bootstrap>().
                AsSingle().
                NonLazy();
        }
    }
}