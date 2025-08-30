using Cysharp.Threading.Tasks;

namespace _Asteroids.Scripts.Services
{
    public interface IServiceInitialize
    {
        UniTask Initialize();
    }
}