using UnityEngine;

namespace Scripts
{
    public interface IReadonlyShip
    {
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public double Rotation { get; set; }
    }
}