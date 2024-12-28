using _Asteroids.Scripts.Data;
using Zenject;

namespace _Asteroids.Scripts.Installers.Data
{
    public class GameplayStatisticsUpdaterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<GameplayStatisticsUpdater>().
                AsSingle();
        }
    }
}