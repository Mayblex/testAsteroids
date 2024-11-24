using UnityEngine;

namespace Scripts
{
    public class UFOFactory : IFactory
    {
        private const string Path = "Prefabs/UFO";

        private readonly GameObject _ufoPrefab; 
        
        public UFOFactory(GameObject ufoPrefab)
        {
            _ufoPrefab = ufoPrefab;
        }
        
        public GameObject Create(Vector2 position)
        {
            return Object.Instantiate(_ufoPrefab, position, Quaternion.identity);
        }
        
        // private GameObject Instantiate(string path, Vector2 position)
        // {
        //     var prefab = Resources.Load<GameObject>(path);
        //     return Object.Instantiate(prefab, position, Quaternion.identity);
        // }
    }
}