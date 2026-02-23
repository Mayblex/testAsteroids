using _Asteroids.Scripts.Data;
using _Asteroids.Scripts.Gameplay.Statistics;
using _Asteroids.Scripts.Services;
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
            
            Container.
                Bind<ScoreCalculator>().
                AsSingle();
            
            Container.
                Bind<RunResultService>().
                AsSingle();
        }
    }
}