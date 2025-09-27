using _Asteroids.Scripts.Data;
using Zenject;

namespace _Asteroids.Scripts.Installers.Data
{
    public class GameplayStatisticsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<GameplayStatistics>().
                AsSingle();
            
            Container.
                Bind<GameplayStatisticsUpdater>().
                AsSingle();
        }
    }
}