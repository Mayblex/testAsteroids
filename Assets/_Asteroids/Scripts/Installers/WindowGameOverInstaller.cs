using _Asteroids.Scripts.UI;
using Zenject;

namespace _Asteroids.Scripts.Installers
{
    public class WindowGameOverInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<WindowGameOver>().
                FromComponentInHierarchy().
                AsSingle();
        }
    }
}