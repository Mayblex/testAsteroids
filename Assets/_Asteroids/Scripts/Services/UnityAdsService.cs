using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Advertisements;

namespace _Asteroids.Scripts.Services
{
    public class UnityAdsService : IAdsService, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        public event Action OnRewardedAdCompleted = delegate { };
        
        private const string ANDROID_GAME_ID = "5796925";
        private const string TEST_GAME_ID = "1234567";
        private const string REWARDED_AD = "Rewarded_Android";
        private const string INTERSTITIAL_AD = "Interstitial_Android";
        private bool _testMode = true;
        private string _gameId;
        
        private bool _initialized;
        private UniTaskCompletionSource _initTcs;

        public async UniTask Initialize()
        {
#if UNITY_ANDROID
            _gameId = NDROID_GAME_ID;
#elif UNITY_EDITOR
            _gameId = TEST_GAME_ID;
#endif
            if (!Advertisement.isInitialized && Advertisement.isSupported)
            {
                _initialized = Advertisement.isInitialized;
            }
            else
            {
                _initTcs = new UniTaskCompletionSource();
                Advertisement.Initialize(_gameId, _testMode, this);
                await _initTcs.Task;
            }
            
            LoadRewardedAd();
            LoadInterstitialAd();
        }
        
        public void OnInitializationComplete()
        {
            _initialized = true;
            _initTcs?.TrySetResult();
            Debug.Log("Unity Ads init complete");
        }
        
        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            _initialized = false;
            _initTcs?.TrySetResult();
            Debug.LogError($"Unity Ads init failed: {error} - {message}");
        }

        public void LoadRewardedAd() => 
            Advertisement.Load(REWARDED_AD, this);

        public void LoadInterstitialAd() => 
            Advertisement.Load(INTERSTITIAL_AD, this);

        public void ShowRewardedAd()
        {
            Advertisement.Show(REWARDED_AD, this);
        }

        public void ShowInterstitialAd() => 
            Advertisement.Show(INTERSTITIAL_AD, this);

        public void OnUnityAdsAdLoaded(string adUnitId) => 
            Debug.Log("Ad loaded: " + adUnitId);

        public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message) => 
            Debug.LogError($"Failed to load Ad Unit {adUnitId}: {error} - {message}");

        public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message) => 
            Debug.LogError($"Error showing Ad Unit {adUnitId}: {error} - {message}");

        public void OnUnityAdsShowStart(string adUnitId) => 
            Debug.Log("Ad started: " + adUnitId);

        public void OnUnityAdsShowClick(string adUnitId) => 
            Debug.Log("Ad clicked: " + adUnitId);

        public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
        {
            Debug.Log($"Ad completed: {adUnitId} with state: {showCompletionState}");
            if (adUnitId.Equals(REWARDED_AD) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
            {
                OnRewardedAdCompleted?.Invoke();
            }
        }
    }
}