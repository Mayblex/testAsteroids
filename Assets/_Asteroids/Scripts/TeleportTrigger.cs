using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class TeleportTrigger : MonoBehaviour
    {
        [SerializeField] private BoxCollider _collider;
        [SerializeField] private Border _border;

        [SerializeField] private Vector3 _exitPosition;

        private void OnValidate()
        {
            _collider ??= GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Rigidbody rigidbody = other.GetComponent<Rigidbody>();
            Vector3 enterPosition = rigidbody.transform.position;
            Vector3 exitPosition = _exitPosition;
            float additionDistance = 0f;

            if (other.TryGetComponent<TeleportObject>(out TeleportObject teleportObject))
                additionDistance = teleportObject.AdditionDistance;

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

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color32(80, 115, 205, 70);
            Gizmos.DrawCube(transform.position + _collider.center, _collider.size);
        }
    }
}