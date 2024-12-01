using System;
using UnityEngine;

namespace Scripts
{
    public class Asteroid : AsteroidBase
    {
        public event Action<Vector3> Creating;

        private protected override void OnDestroy()
        {
            base.OnDestroy();
            Creating = null;
        }

        private void OnDisable()
        {
            Creating = null;
        }

        private protected override void PerformOnDie()
        {
            CreateFragment(2);
        }
        
        private void CreateFragment(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Creating?.Invoke(transform.position);
            }
        }
    }
}