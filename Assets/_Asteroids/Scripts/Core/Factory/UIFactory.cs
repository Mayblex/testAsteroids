using _Asteroids.Scripts.UI;
using UnityEngine;

namespace _Asteroids.Scripts.Core.Factory
{
    public class UIFactory
    {
        private readonly Transform _uiRoot;
        
        public UIFactory(Transform uiRoot)
        {
            _uiRoot = uiRoot;
        }
        
        public BaseWindow Create(BaseWindow prefab)
        {
            return Object.Instantiate(prefab, _uiRoot);
        }
    }
}