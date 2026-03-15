using Cysharp.Threading.Tasks;

namespace _Asteroids.Scripts.Services.Assets
{
    public interface IAssetProvider
    {
        UniTask<T> LoadAssetAsync<T>(string address) where T : class;
        UniTask Warmup(params string[] addresses);
        T GetLoaded<T>(string address) where T : class;
        void Release(string address);
        void ReleaseAll();
    }
}