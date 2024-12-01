using System;
using UnityEngine;

namespace Scripts
{
    public interface IPoolable
    {
        public event Action<GameObject> Released;
    }
}