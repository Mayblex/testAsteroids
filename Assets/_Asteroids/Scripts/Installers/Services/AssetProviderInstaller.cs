using _Asteroids.Scripts.Services.Assets;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Installers.Services
{
    public class AssetProviderInstaller : MonoInstaller
    {
        [SerializeField] private AssetCatalogSO _assetCatalog;

        public override void InstallBindings()
        {
            Container.
                Bind<IAssetProvider>().
                To<AddressablesAssetProvider>().
                AsSingle();
            
            Container.
                BindInstance(_assetCatalog).
                AsSingle();
        }
    }
}