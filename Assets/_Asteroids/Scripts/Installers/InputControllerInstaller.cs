using _Asteroids.Scripts.Core.Input;
using Zenject;

namespace _Asteroids.Scripts.Installers
{
    public class InputControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<PlayerInput>().
                AsSingle();

            Container.
                Bind<InputController>().
                AsSingle();
        }
    }
}