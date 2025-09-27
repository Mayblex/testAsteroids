using _Asteroids.Scripts.Core.Input;
using UnityEngine;

namespace _Asteroids.Scripts.Gameplay.Ship
{
    public class ShipHolder
    {
        public Ship Ship { get; private set; }

        public void SetShip(Ship ship) => 
            Ship = ship;

        public IInputHandler GetInputHandler() => 
            Ship.GetComponent<IInputHandler>();

        public IShip GetShip() => 
            Ship.GetComponent<IShip>();

        public Laser GetLaser() => 
            Ship.GetComponentInChildren<Laser>();
    }
}