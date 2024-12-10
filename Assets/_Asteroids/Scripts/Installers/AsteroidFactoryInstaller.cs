using _Asteroids.Scripts.Core.Factory;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Installers
{
    public class AsteroidFactoryInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _asteroidPrefab;
        [SerializeField] private GameObject _fragmentasteroidPrefab;
        [SerializeField] private int _initialSizeAsteroid = 15;
        [SerializeField] private int _initialSizeFragmentAsteroid = 22;
        
        public override void InstallBindings()
        {
            Container.Bind<AsteroidFactory>().
                WithId(InstallerIds.ASTEROID_FACTORY).
                AsCached().
                WithArguments(_asteroidPrefab, _initialSizeAsteroid);
            
            Container.Bind<AsteroidFactory>().
                WithId(InstallerIds.FRAGMENT_ASTEROID_FACTORY).
                AsCached().
                WithArguments(_fragmentasteroidPrefab, _initialSizeFragmentAsteroid);
        }
    }
}