using _Asteroids.Scripts.Core;
using Zenject;

namespace _Asteroids.Scripts.Installers
{
    public class EntryPointInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                BindInterfacesAndSelfTo<EntryPoint>().
                AsCached();
        }
    }
}