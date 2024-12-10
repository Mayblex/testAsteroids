using _Asteroids.Scripts.Core.Factory;
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
                Bind<CommonFactory>().
                AsSingle().
                WithArguments(_shipPrefab, Container);
        }
    }
}