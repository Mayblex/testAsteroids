using _Asteroids.Scripts.Gameplay.Spawn;
using Zenject;

namespace _Asteroids.Scripts.Installers
{
    public class SpawnerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<Spawner>().
                FromComponentInHierarchy().
                AsSingle();
        }
    }
}