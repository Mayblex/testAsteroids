using System;
using UnityEngine;

namespace _Asteroids.Scripts.Gameplay.Asteroids
{
    public class Asteroid : AsteroidBase
    {
        public event Action<GameObject, Vector3> Creating;
        
        private protected override void PerformOnDie()
        {
            CreateFragment(2);
        }
        
        private void CreateFragment(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Creating?.Invoke(gameObject, transform.position);
            }
        }
    }
}