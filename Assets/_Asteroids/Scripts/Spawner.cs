using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts
{
    public class Spawner : MonoBehaviour
    {
        private const float _validToY = 16f;
        private const float _validToX = 33f;
        private const float _invalidToX = 26f;
        private const float _invalidToY = 12f;

        [SerializeField] private GameObject _asteroidPrefab;
        [SerializeField] private GameObject _flyingObjectPrefab;
        [SerializeField] private int _numberAsteroid;
        [SerializeField] private int _numberFO;
        
        private float _time = 25f;
        private float _deltaTime = 7f;

        public void Run()
        {
            Spawn(_numberAsteroid, _asteroidPrefab);
            Spawn(_numberFO, _flyingObjectPrefab);
            StartCoroutine(SpawnObjectsAfterTime());
        }

        private IEnumerator SpawnObjectsAfterTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(_time);

                Spawn(_numberAsteroid, _asteroidPrefab);
                Spawn(_numberFO, _flyingObjectPrefab);

                _time += _deltaTime;
                _numberAsteroid += _numberAsteroid;
                _numberFO += _numberFO;
            }
        }

        private void Spawn(int number, GameObject prefab)
        {
            for (int i = 0; i < number; i++)
            {
                Instantiate(prefab, GeneratePosition(), transform.rotation);
            }
        }

        private Vector2 GeneratePosition()
        {
            Vector2 position = Vector2.zero;

            while(position.x < _invalidToX && position.y < _invalidToY)
            {
                position.y = Random.Range(-_validToY, _validToY);
                position.x = Random.Range(-_validToX, _validToX);
            }

            return position;
        }
    }
}