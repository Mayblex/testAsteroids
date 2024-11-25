using System;
using UnityEngine;

namespace Scripts
{
    public class BorderTeleportation : MonoBehaviour
    {
        private Camera _camera;
        private Rigidbody _rigidbody;
        private Vector2 _screenBorders;

        private void Start()
        {
            _camera = Camera.main;
            _rigidbody = GetComponent<Rigidbody>();
            float verticalSize = _camera.orthographicSize;
            float horizontalSize = verticalSize * _camera.aspect;
            _screenBorders = new Vector2(horizontalSize, verticalSize);
        }

        private void FixedUpdate()
        {
            Vector3 position = _rigidbody.position;

            if (position.x > _screenBorders.x)
                position.x = -_screenBorders.x;
            else if (position.x < _screenBorders.x)
                position.x = _screenBorders.x;

            if (position.y > _screenBorders.y)
                position.y = _screenBorders.y;
            else if (position.y < _screenBorders.y)
                position.y = _screenBorders.y;
            
            _rigidbody.MovePosition(position);
        }
    }
}