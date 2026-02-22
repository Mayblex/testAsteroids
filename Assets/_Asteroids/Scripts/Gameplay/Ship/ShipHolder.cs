using _Asteroids.Scripts.Core.Input;
using UnityEngine;

namespace _Asteroids.Scripts.Gameplay.Ship
{
    public class ShipHolder
    {
        public Ship Ship { get; private set; }
        public Laser Laser { get; private set; }
        public IInputHandler InputHandler { get; private set; }

        public void SetShip(Ship ship)
        {
            Ship = ship;
            Laser = ship.GetComponentInChildren<Laser>();
            InputHandler = ship.GetComponent<IInputHandler>();
        }

        public IInputHandler GetInputHandler() => 
            Ship.GetComponent<IInputHandler>();

        public Laser GetLaser() => 
            Ship.GetComponentInChildren<Laser>();
    }
}