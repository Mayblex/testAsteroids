using _Asteroids.Scripts.Data;
using UnityEngine;

namespace _Asteroids.Scripts.Gameplay.Statistics
{
    public class ScoreCalculator
    {
        private const int AsteroidPoints = 100;
        private const int UFOPoints = 500;
        private const float PointsPerSecond = 10f;

        public int Calculate(GameplayStatistics stats)
        {
            int timePoints = Mathf.FloorToInt(stats.PlayTimeSeconds * PointsPerSecond);
            
            int totalScore = stats.DestroyedAsteroids * AsteroidPoints 
                             + stats.DestroyedUFOs * UFOPoints 
                             + timePoints;
            
            return totalScore;
        }
    }
}