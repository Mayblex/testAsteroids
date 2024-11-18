﻿using UnityEngine;

namespace Scripts
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