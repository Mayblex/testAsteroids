using _Asteroids.Scripts.Data;
using _Asteroids.Scripts.Gameplay.Statistics;
using Cysharp.Threading.Tasks;

namespace _Asteroids.Scripts.Services
{
    public class RunResultService
    {
        private readonly GameplayStatistics _stats;
        private readonly ScoreCalculator _scoreCalculator;
        private readonly SaveState _saveState;
        private readonly ISaveService _saveService;
        
        public RunResultService(GameplayStatistics stats, ScoreCalculator scoreCalculator, 
            SaveState saveState, ISaveService saveService)
        {
            _stats = stats;
            _scoreCalculator = scoreCalculator;
            _saveState = saveState;
            _saveService = saveService;
        }

        public async UniTask<int> FinalizeRunAndSave()
        {
            int finalScore = _scoreCalculator.Calculate(_stats);
            
            if (finalScore > _saveState.Data.BestScore)
                _saveState.Data.BestScore = finalScore;
            
            await _saveService.Save(_saveState.Data);
            
            return finalScore;
        }
    }
}