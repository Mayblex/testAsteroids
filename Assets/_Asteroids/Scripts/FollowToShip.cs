using UnityEngine;

namespace Scripts
{
    public class FollowToShip : MonoBehaviour
    {
        private const float MinimalDistance = 4f;

        [SerializeField] private float _speedFollow = 5f;
        
        private Transform _target;

        private void Awake()
        {
            _target = GameObject.FindWithTag(nameof(Ship)).transform;
        }

        private void Update()
        {
            if (Vector2.Distance(transform.position, _target.position) >= MinimalDistance)
                transform.position = Vector3.MoveTowards(transform.position, _target.position, _speedFollow * Time.deltaTime);
        }
    }
}