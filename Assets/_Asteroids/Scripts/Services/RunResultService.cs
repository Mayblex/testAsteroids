using _Asteroids.Scripts.Data;
using _Asteroids.Scripts.Gameplay.Statistics;
using Cysharp.Threading.Tasks;

namespace _Asteroids.Scripts.Services
{
    public class RunResultService
    {
        private readonly GameplayStatistics _stats;
        private readonly ScoreCalculator _scoreCalculator;
        private readonly SaveData _saveData;
        private readonly ISaveService _saveService;
        
        public RunResultService(GameplayStatistics stats, ScoreCalculator scoreCalculator, 
            SaveData saveData, ISaveService saveService)
        {
            _stats = stats;
            _scoreCalculator = scoreCalculator;
            _saveData = saveData;
            _saveService = saveService;
        }

        public async UniTask FinalizeRunAndSave()
        {
            int finalScore = _scoreCalculator.Calculate(_stats);
            
            if (finalScore > _saveData.BestScore)
                _saveData.BestScore = finalScore;
            
            await _saveService.Save(_saveData);
        }
    }
}