using System;
using Cysharp.Threading.Tasks;

namespace _Asteroids.Scripts.Services
{
    public interface IAdsService
    {
        event Action OnRewardedAdCompleted;
        
        UniTask Initialize();
        void LoadRewardedAd();
        void ShowRewardedAd();
        void LoadInterstitialAd();
        void ShowInterstitialAd();
    }
}