using _Asteroids.Scripts.Data;
using Cysharp.Threading.Tasks;

namespace _Asteroids.Scripts.Services.Save
{
    public interface ISaveService
    {
        SaveData Load();
        UniTask Save(SaveData data);
        bool HasSave();
        void Clear();
    }
}