using UnityEngine;

namespace _Asteroids.Scripts.Core.Factory
{
    public class ShipFactory : IFactory
    {
        private readonly GameObject _shipPrefab;

        public ShipFactory(GameObject shipPrefab)
        {
            _shipPrefab = shipPrefab;
        }
        public GameObject Create(Vector2 position)
        {
            return Object.Instantiate(_shipPrefab, position, Quaternion.identity);
        }
    }
}