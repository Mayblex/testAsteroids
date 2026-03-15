using Cysharp.Threading.Tasks;

namespace _Asteroids.Scripts.Services.RemoteConfig
{
    public interface IRemoteConfigService
    {
        public UniTask Initialize();
        public T GetValue<T>(string key);
    }
}