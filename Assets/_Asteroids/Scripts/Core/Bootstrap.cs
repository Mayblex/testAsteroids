using _Asteroids.Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core
{
    public class Bootstrap : IInitializable
    {
        private readonly ZenjectSceneLoader _sceneLoader;
        private readonly FirebaseInitialize _firebaseInitialize;
        private readonly IAnalyticsService _analyticsService;
        private readonly IRemoteConfigService _configService;
        private readonly IAdsService _adsService;
        
        public Bootstrap(ZenjectSceneLoader sceneLoader, IAnalyticsService analyticsService, 
            IRemoteConfigService configService, IAdsService adsService)
        {
            _sceneLoader = sceneLoader;
            _firebaseInitialize = new FirebaseInitialize();
            _analyticsService = analyticsService;
            _configService = configService;
            _adsService = adsService;
        }
        
        public async void Initialize()
        {
            Debug.Log("Start");

            await _firebaseInitialize.Initialize();
            await _analyticsService.Initialize();
            await _configService.Initialize();
            await _adsService.Initialize();
            
            _sceneLoader.LoadScene("MainScene");
        }
    }
}