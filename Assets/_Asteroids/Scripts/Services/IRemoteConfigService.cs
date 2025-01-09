using System.Threading.Tasks;

namespace _Asteroids.Scripts.Services
{
    public interface IRemoteConfigService
    {
        public Task Initialize();
        public T GetValue<T>(string key);
    }
}