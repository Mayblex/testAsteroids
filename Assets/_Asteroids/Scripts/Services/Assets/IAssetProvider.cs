using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Asteroids.Scripts.Services.Assets
{
    public interface IAssetProvider
    {
        UniTask<T> LoadAssetAsync<T>(string address) where T : Object;
        UniTask Warmup(params string[] addresses);
        T GetLoadedComponent<T>(string address) where T : Component;
        void Release(string address);
        void ReleaseAll();
    }
}