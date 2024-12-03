using _Asteroids.Scripts.Core.Factory;
using _Asteroids.Scripts.Core.Input;
using _Asteroids.Scripts.Gameplay.Ship;
using _Asteroids.Scripts.Gameplay.Spawn;
using _Asteroids.Scripts.UI;
using UnityEngine;

namespace _Asteroids.Scripts.Core
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private UIStatistics _uiStatistics;
        [SerializeField] private Spawner _spawner;
        [SerializeField] private GameObject _asteroidPrefab;
        [SerializeField] private GameObject _fragmentasteroidPrefab;
        [SerializeField] private GameObject _ufoPrefab;
        [SerializeField] private GameObject _shipPrefab;

        private PlayerInput _playerInput;
        private IInputHandler _inputHandler;
        private InputController _inputController;
        private CommonFactory _shipFactory;
        private CommonFactory _asteroidFactory;
        private CommonFactory _fragmentAsteroidFactory;
        private UFOFactory _ufoFactory;
        private Ship _ship;
        private Laser _laser;
        private GameObject _player;

        private void Awake()
        {
            _shipFactory = new CommonFactory(_shipPrefab);
            _player = _shipFactory.Create(Vector2.zero);
            _ship = _player.GetComponent<Ship>();
            _ship.Initialize();
            _laser = _player.GetComponentInChildren<Laser>();
            _laser.Initialize();
            _asteroidFactory = new CommonFactory(_asteroidPrefab);
            _fragmentAsteroidFactory = new CommonFactory(_fragmentasteroidPrefab);
            _ufoFactory = new UFOFactory(_ufoPrefab, _ship.transform);
            _playerInput = new PlayerInput();
            _inputHandler = _player.GetComponent<IInputHandler>();
            _inputController = new InputController(_playerInput, _inputHandler);
        }

        private void Start()
        {
            _ship.Constract(_laser);
            _uiStatistics.Constract(_ship, _laser);
            _uiStatistics.Run();
            _spawner.Constract(_asteroidFactory, _fragmentAsteroidFactory, _ufoFactory);
            _spawner.Run();
        }

        private void Update()
        {
            _inputController.ProcessInput();
        }

        private void OnDestroy()
        {
            _inputController.Dispose();
        }
    }
}