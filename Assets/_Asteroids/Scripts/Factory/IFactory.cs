using UnityEngine;

namespace Scripts.Factory
{
    public interface IFactory
    {
        public GameObject Create(Vector2 position);
    }
}