using System;
using UnityEngine;

namespace _Asteroids.Scripts.Core.Pool
{
    public interface IPoolable
    {
        public event Action<GameObject> Released;
    }
}