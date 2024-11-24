using UnityEngine;

namespace Scripts
{
    public class ShipFactory : IFactory
    {
        private const string Path = "Prefabs/Ship";

        public GameObject Create(Vector2 position)
        {
            return Instantiate(Path, position);
        }
        
        private GameObject Instantiate(string path, Vector2 position)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }

    }
}