using _Asteroids.Scripts.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core
{
    public class Bootstrap : IInitializable
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IServiceInitialize _serviceInitialize;
        private readonly IAnalyticsService _analyticsService;
        private readonly IRemoteConfigService _configService;
        private readonly IAdsService _adsService;

        public Bootstrap(ISceneLoader sceneLoader, IServiceInitialize serviceInitialize,
            IAnalyticsService analyticsService,
            IRemoteConfigService configService, IAdsService adsService)
        {
            _sceneLoader = sceneLoader;
            _serviceInitialize = serviceInitialize;
            _analyticsService = analyticsService;
            _configService = configService;
            _adsService = adsService;
        }

        public void Initialize()
        {
            InitializeAsync().Forget();
        }

        private async UniTask InitializeAsync()
        {
            Debug.Log("Start");

            await _serviceInitialize.Initialize();

            await UniTask.WhenAll(
                _analyticsService.Initialize(),
                _configService.Initialize(),
                _adsService.Initialize());

            _sceneLoader.LoadGame();
        }
    }
}