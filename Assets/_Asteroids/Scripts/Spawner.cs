using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts
{
    public class Spawner : MonoBehaviour
    {
        private const float ValidToY = 16f;
        private const float ValidToX = 33f;
        private const float InvalidToX = 26f;
        private const float InvalidToY = 12f;

        [SerializeField] private int _numberAsteroid;
        [SerializeField] private int _numberUFO;

        private AsteroidFactory _asteroidFactory;
        private UFOFactory _ufoFactory;
        private ObjectPool _asteroidPool;
        private ObjectPool _ufoPool;
        private float _time = 25f;
        private float _deltaTime = 7f;

        public void Constract(AsteroidFactory asteroidFactory, UFOFactory ufoFactory)
        {
            _asteroidFactory = asteroidFactory;
            _ufoFactory = ufoFactory;
        }
        
        public void Run()
        {
            Spawn(_numberAsteroid, _numberUFO);
            StartCoroutine(SpawnObjectsAfterTime());
        }

        private IEnumerator SpawnObjectsAfterTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(_time);

                Spawn(_numberAsteroid, _numberUFO);

                _time += _deltaTime;
                _numberAsteroid += _numberAsteroid;
                _numberUFO += _numberUFO;
            }
        }

        private void Spawn(int numberAsteroid, int numberUFO)
        {
            for (int i = 0; i < numberAsteroid; i++)
            {
                _asteroidFactory.Create(GeneratePosition());
            }

            for (int i = 0; i < numberUFO; i++)
            {
                _ufoFactory.Create(GeneratePosition());
            }
        }

        private Vector2 GeneratePosition()
        {
            Vector2 position = Vector2.zero;

            while(position.x < InvalidToX && position.y < InvalidToY)
            {
                position.y = Random.Range(-ValidToY, ValidToY);
                position.x = Random.Range(-ValidToX, ValidToX);
            }

            return position;
        }
    }
}