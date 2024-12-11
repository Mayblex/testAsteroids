using _Asteroids.Scripts.Core.Factory;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Installers
{
    public class UFOFactoryInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _ufoPrefub;
        [SerializeField] private int _initialSize;
        
        public override void InstallBindings()
        {
            Container.
                Bind<UFOFactory>().
                AsSingle().
                WithArguments(_ufoPrefub, _initialSize, Container);
        }
    }
}