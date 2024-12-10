using System;
using UnityEngine;

namespace _Asteroids.Scripts.Gameplay.Asteroids
{
    public class Asteroid : AsteroidBase
    {
        public event Action<GameObject, int, Vector3> Creating;
        
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