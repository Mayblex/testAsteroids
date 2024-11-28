using System;
using UnityEngine;

namespace Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private UIStatistics _uiStatistics;
        [SerializeField] private Spawner _spawner;
        [SerializeField] private GameObject _asteroidPrefab;
        [SerializeField] private GameObject _ufoPrefab;
        [SerializeField] private GameObject _shipPrefab;
        
        [SerializeField] private InputController _inputController;
        private ShipFactory _shipFactory;
        private AsteroidFactory _asteroidFactory;
        private UFOFactory _ufoFactory;
        private Ship _ship;
        private Laser _laser;
        private GameObject _player;

        private void Awake()
        {
            _shipFactory = new ShipFactory(_shipPrefab);
            _player = _shipFactory.Create(Vector2.zero);
            _ship = _player.GetComponent<Ship>();
            _ship.Initialize();
            _inputController = _player.GetComponent<InputController>();
            //_inputController.Initialize();
            _laser = _player.GetComponentInChildren<Laser>();
            _laser.Initialize();
            _asteroidFactory = new AsteroidFactory(_asteroidPrefab);
            _ufoFactory = new UFOFactory(_ufoPrefab, _ship.transform);
        }

        private void Start()
        {
            _ship.Constract(_laser);
            _uiStatistics.Constract(_ship, _laser);
            _uiStatistics.Run();
            _spawner.Constract(_asteroidFactory, _ufoFactory);
            _spawner.Run();
        }
    }
}