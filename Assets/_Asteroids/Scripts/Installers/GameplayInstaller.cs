using _Asteroids.Scripts.Core.Factory;
using _Asteroids.Scripts.Core.Input;
using _Asteroids.Scripts.Gameplay.Ship;
using _Asteroids.Scripts.Gameplay.Spawn;
using _Asteroids.Scripts.Services.Assets;
using UnityEngine;
using Zenject;
using static _Asteroids.Scripts.Installers.InstallerIds;

namespace _Asteroids.Scripts.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private int _initialSizeAsteroid = 15;
        [SerializeField] private int _initialSizeFragmentAsteroid = 22;
        [SerializeField] private int _initialSize;
        
        private AssetCatalogSO _catalog;

        [Inject]
        public void Construct(AssetCatalogSO catalog)
        {
            _catalog = catalog;
        }
        
        public override void InstallBindings()
        {
            Container.
                Bind<PlayerInput>().
                AsSingle();

            Container.
                Bind<InputController>().
                AsSingle();
            
            Container.
                Bind<ShipHolder>().
                AsSingle().
                NonLazy();
            
            Container.
                Bind<ShipFactory>().
                AsSingle().
                WithArguments(_catalog.ShipPrefab, Container);
            
            Container.Bind<AsteroidFactory>().
                WithId(ASTEROID_FACTORY).
                AsCached().
                WithArguments(_catalog.AsteroidPrefab, _initialSizeAsteroid);
            
            Container.Bind<AsteroidFactory>().
                WithId(FRAGMENT_ASTEROID_FACTORY).
                AsCached().
                WithArguments(_catalog.FragmentAsteroidPrefab, _initialSizeFragmentAsteroid);
            
            Container.
                Bind<UFOFactory>().
                AsSingle().
                WithArguments(_catalog.UFOPrefab, _initialSize, Container);
            
            Container.
                Bind<Spawner>().
                AsSingle();
        }
    }
}