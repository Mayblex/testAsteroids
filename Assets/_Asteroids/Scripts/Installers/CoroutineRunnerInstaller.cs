using _Asteroids.Scripts.Core;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Installers
{
    public class CoroutineRunnerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var coroutineRunner = new GameObject(InstallerIds.COROUTINE_RUNNER).AddComponent<CoroutineRunner>();
            
            DontDestroyOnLoad(coroutineRunner);
            
            Container.
                Bind<CoroutineRunner>().
                FromInstance(coroutineRunner).
                AsSingle().
                NonLazy();
        }
    }
}