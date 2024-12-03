using UnityEngine;

namespace _Asteroids.Scripts.Core.Factory
{
    public interface IFactory
    {
        public GameObject Create(Vector2 position);
    }
}