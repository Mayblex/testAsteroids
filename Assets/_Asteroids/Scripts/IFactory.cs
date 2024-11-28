using UnityEngine;

namespace Scripts
{
    public interface IFactory
    {
        public GameObject Create(Vector2 position);
    }
}