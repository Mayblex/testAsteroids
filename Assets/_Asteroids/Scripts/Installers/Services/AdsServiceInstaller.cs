using _Asteroids.Scripts.Services;
using _Asteroids.Scripts.Services.Ads;
using Zenject;

namespace _Asteroids.Scripts.Installers.Services
{
    public class AdsServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<IAdsService>().
                To<UnityAdsService>().
                AsSingle();
        }
    }
}