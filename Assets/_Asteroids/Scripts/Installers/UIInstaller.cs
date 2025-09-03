using _Asteroids.Scripts.UI;
using Zenject;

namespace _Asteroids.Scripts.Installers
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<UIStatistics>().
                FromComponentInHierarchy().
                AsSingle();
            
            Container.
                Bind<WindowGameOver>().
                FromComponentInHierarchy().
                AsSingle();
        }
    }
}