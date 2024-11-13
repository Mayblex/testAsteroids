using System;
using UnityEngine;

namespace Scripts
{
    public class Asteroid : AsteroidBase
    {
        [SerializeField] private GameObject _fragmentAsteroidPrefab;

        private void OnDestroy()
        {
            CreateFragment(2);
        }
        
        private void CreateFragment(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Instantiate<GameObject>(_fragmentAsteroidPrefab, transform.position, transform.rotation);
            }
        }
    }
}