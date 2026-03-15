using _Asteroids.Scripts.Data;
using Zenject;

namespace _Asteroids.Scripts.Services.Save
{
    public class SaveState : IInitializable
    {
        private readonly ISaveService _saveService;
        
        public SaveData Data { get; set; } = new SaveData();

        public SaveState(ISaveService saveService)
        {
            _saveService = saveService;
        }
        
        public void Initialize()
        {
            Data =  _saveService.Load();
        }
    }
}