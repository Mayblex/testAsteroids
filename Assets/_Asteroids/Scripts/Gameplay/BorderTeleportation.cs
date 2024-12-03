using UnityEngine;

namespace _Asteroids.Scripts.Gameplay
{
    public class BorderTeleportation : MonoBehaviour
    {
        private Camera _camera;
        private Rigidbody _rigidbody;
        private float _bottom;
        private float _top;
        private float _left;
        private float _right;

        private void Start()
        {
            _camera = Camera.main;
            _rigidbody = GetComponent<Rigidbody>();

            Vector3 bottomLeft = _camera.ScreenToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
            Vector3 topRight = 
                _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.nearClipPlane));

            _bottom = bottomLeft.y;
            _top = topRight.y;
            _left = bottomLeft.x;
            _right = topRight.x;
        }

        private void FixedUpdate()
        {
            Vector3 position = _rigidbody.position;

            if (position.x > _right)
                position.x = _left;
            else if (position.x < _left)
                position.x = _right;
            
            if (position.y > _top)
                position.y = _bottom;
            else if (position.y < _bottom)
                position.y = _top;

            _rigidbody.MovePosition(position);
        }
    }
}