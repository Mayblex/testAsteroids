using _Asteroids.Scripts.Core.Input;
using UnityEngine;

namespace _Asteroids.Scripts.Gameplay.Ship
{
    public class ShipHolder
    {
        public GameObject Ship { get; private set; }

        public void SetShip(GameObject ship)
        {
            Ship = ship;
        }

        public IInputHandler GetInputHandler()
        {
            return Ship.GetComponent<IInputHandler>();
        }
    }
}