using _Asteroids.Scripts.Gameplay.Ship;
using _Asteroids.Scripts.Services;
using _Asteroids.Scripts.Services.Ads;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.UI
{
    public class WindowGameOver : MonoBehaviour
    {
        [SerializeField] private GameObject _windowRewarded;
        [SerializeField] private GameObject _windowFinish;
        [SerializeField] private TextMeshProUGUI _scoreText;
        
        private IAdsService _adsService;
        private ShipHolder _shipHolder;
        private RunResultService _runResultService;
        private IShip _ship;
        private bool _hasWatchedRewarded = false;

        [Inject]
        public void Construct(IAdsService adsService, ShipHolder shipHolder, RunResultService runResultService)
        {
            _adsService = adsService;
            _shipHolder = shipHolder;
            _runResultService = runResultService;
        }

        public void Initialize()
        {
            CloseWindowRewarded();
            CloseWindowFinish();
            _ship = _shipHolder.Ship;
            _ship.Died += ShowWindowRewarded;
        }

        public void ShowRewardedAd()
        {
            _adsService.ShowRewardedAd();
            _hasWatchedRewarded = true;
        }

        public void GameOver()
        {
            FinalGameOverAsync().Forget();
        }

        private async UniTask FinalGameOverAsync()
        {
            if (!_hasWatchedRewarded)
                ShowInterstitialAd();

            int finalScore = await _runResultService.FinalizeRunAndSave();
            _scoreText.text = finalScore.ToString();
            
            ShowWindowFinish();
        }

        private void OnDestroy()
        {
            _ship.Died -= ShowWindowRewarded;
        }

        private void CloseWindowRewarded() => 
            _windowRewarded.SetActive(false);

        private void ShowWindowRewarded() => 
            _windowRewarded.SetActive(true);

        private void CloseWindowFinish() => 
            _windowFinish.SetActive(false);

        private void ShowWindowFinish() => 
            _windowFinish.SetActive(true);

        private void ShowInterstitialAd() => 
            _adsService.ShowInterstitialAd();
    }
}