using _Asteroids.Scripts.Core;
using UnityEngine;

namespace _Asteroids.Scripts.Gameplay.Ship
{
    public class LaserTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamageable>(out IDamageable recipient))
            {
                recipient.TakeDamage();
            }
        }
    }
}