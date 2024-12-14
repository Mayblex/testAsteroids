using _Asteroids.Scripts.Core.Input;
using UnityEngine;

namespace _Asteroids.Scripts.Gameplay.Ship
{
    public class ShipHolder
    {
        public GameObject Ship { get; private set; }

        public void SetShip(GameObject ship) => 
            Ship = ship;

        public IInputHandler GetInputHandler() => 
            Ship.GetComponent<IInputHandler>();

        public IReadonlyShip GetReadonlyShip() => 
            Ship.GetComponent<IReadonlyShip>();

        public Laser GetLaser() => 
            Ship.GetComponentInChildren<Laser>();
    }
}