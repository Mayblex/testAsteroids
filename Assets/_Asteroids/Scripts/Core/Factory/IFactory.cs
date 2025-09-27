using UnityEngine;

namespace _Asteroids.Scripts.Core.Factory
{
    public interface IFactory<T>
    {
        public T Create(Vector2 position);
    }
}