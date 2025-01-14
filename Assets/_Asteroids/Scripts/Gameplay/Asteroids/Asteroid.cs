using System;
using _Asteroids.Scripts.Configs;
using UnityEngine;

namespace _Asteroids.Scripts.Gameplay.Asteroids
{
    public class Asteroid : AsteroidBase
    {
        private const string ASTEROID_CONFIG = "asteroidConfig";
        
        private AsteroidConfig _config;
        
        public event Action<GameObject, int, Vector3> Creating;

        private protected override void ApplyConfig()
        {
            _config = _configService.GetValue<AsteroidConfig>(ASTEROID_CONFIG);
            _speed = _config.Speed;
        }

        private protected override void PerformOnDie()
        {
            CreateFragment(2);
        }
        
        private void CreateFragment(int number)
        {
            Creating?.Invoke(gameObject, number, transform.position);
        }
    }
}