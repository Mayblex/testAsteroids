using _Asteroids.Scripts.UI;
using _Asteroids.Scripts.UI.Statistics;
using Zenject;

namespace _Asteroids.Scripts.Installers
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<WindowGameOver>().
                FromComponentInHierarchy().
                AsSingle();

            Container.
                Bind<StatisticsView>().
                FromComponentInHierarchy().
                AsSingle();

            Container.
                Bind<StatisticsPresenter>().
                AsSingle();
        }
    }
}