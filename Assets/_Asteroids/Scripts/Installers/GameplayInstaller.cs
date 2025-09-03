using _Asteroids.Scripts.Core.Factory;
using _Asteroids.Scripts.Core.Input;
using _Asteroids.Scripts.Gameplay.Ship;
using _Asteroids.Scripts.Gameplay.Spawn;
using UnityEngine;
using Zenject;
using static _Asteroids.Scripts.Installers.InstallerIds;

namespace _Asteroids.Scripts.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _shipPrefab;
        [SerializeField] private GameObject _asteroidPrefab;
        [SerializeField] private GameObject _fragmentasteroidPrefab;
        [SerializeField] private int _initialSizeAsteroid = 15;
        [SerializeField] private int _initialSizeFragmentAsteroid = 22;
        [SerializeField] private GameObject _ufoPrefub;
        [SerializeField] private int _initialSize;
        
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
                WithArguments(_shipPrefab, Container);
            
            Container.Bind<AsteroidFactory>().
                WithId(ASTEROID_FACTORY).
                AsCached().
                WithArguments(_asteroidPrefab, _initialSizeAsteroid);
            
            Container.Bind<AsteroidFactory>().
                WithId(FRAGMENT_ASTEROID_FACTORY).
                AsCached().
                WithArguments(_fragmentasteroidPrefab, _initialSizeFragmentAsteroid);
            
            Container.
                Bind<UFOFactory>().
                AsSingle().
                WithArguments(_ufoPrefub, _initialSize, Container);
            
            Container.
                Bind<Spawner>().
                AsSingle();
        }
    }
}