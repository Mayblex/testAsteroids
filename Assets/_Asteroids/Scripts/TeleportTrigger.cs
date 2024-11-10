using System;
using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class TeleportTrigger : MonoBehaviour
    {
        [SerializeField] private BoxCollider _collider;
        [SerializeField] private Border _border;

        [SerializeField] private Vector3 _exitPosition;

        private bool _entered = false;

        private void OnValidate()
        {
            _collider ??= GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_entered)
                return;

            _entered = true;
            
            Rigidbody teleportObject = other.GetComponent<Rigidbody>();
            float magnitude = teleportObject.linearVelocity.magnitude;
            Vector3 enterPosition = teleportObject.transform.position;
            Vector3 exitPosition = _exitPosition;
            float additionDistance = 0f;

            if (other.gameObject.CompareTag("Ship"))
                additionDistance = 2f;
            if (other.gameObject.CompareTag("Asteroid"))
                additionDistance = 3f;
            if (other.gameObject.CompareTag("FragmentAsteroid"))
                additionDistance = 1.5f;

            switch (_border)
            {
                case Border.Left:
                    exitPosition = new Vector3(_exitPosition.x - additionDistance / 2, enterPosition.y);
                    break;
                case Border.Right:
                    exitPosition = new Vector3(_exitPosition.x + additionDistance / 2, enterPosition.y);
                    break;
                case Border.Top:
                    exitPosition = new Vector3(enterPosition.x, _exitPosition.y + additionDistance / 2);
                    break;
                case Border.Bottom:
                    exitPosition = new Vector3(enterPosition.x, _exitPosition.y - additionDistance / 2);
                    break;
            }

            other.transform.position = exitPosition;
        }

        private void OnTriggerExit(Collider other)
        {
            _entered = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color32(80, 115, 205, 70);
            Gizmos.DrawCube(transform.position + _collider.center, _collider.size);
        }
    }
}