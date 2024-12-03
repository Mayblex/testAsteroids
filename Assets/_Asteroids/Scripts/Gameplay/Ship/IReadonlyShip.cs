using System;
using UnityEngine;

namespace _Asteroids.Scripts.Gameplay.Ship
{
    public interface IReadonlyShip
    {
        public event Action Died;
        
        public Vector2 Position { get; }
        public float Speed { get; }
        public double Rotation { get; }
    }
}