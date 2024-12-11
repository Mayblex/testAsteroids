using _Asteroids.Scripts.Core.Factory;
using _Asteroids.Scripts.Gameplay.Ship;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Installers
{
    public class PlayerFactoryInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _shipPrefab;
        
        public override void InstallBindings()
        {
            Container.
                Bind<ShipHolder>().
                AsSingle().
                NonLazy();
            
            Container.
                Bind<ShipFactory>().
                AsSingle().
                WithArguments(_shipPrefab, Container);
        }
    }
}