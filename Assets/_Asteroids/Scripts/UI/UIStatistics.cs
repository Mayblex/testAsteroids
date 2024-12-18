using _Asteroids.Scripts.Gameplay.Ship;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.UI
{
    public class UIStatistics : MonoBehaviour
    {
        private const string TEXT_SPEED = "Speed: ";
        private const string TEXT_ROTATION = "Rotation: ";
        private const string TEXT_NUMBER_LASER = "Laser: ";
        private const string TEXT_TIME_RECHARGE = "Time: ";

        [SerializeField] private TextMeshProUGUI _position;
        [SerializeField] private TextMeshProUGUI _speed;
        [SerializeField] private TextMeshProUGUI _rotation;
        [SerializeField] private TextMeshProUGUI _numberLaser;
        [SerializeField] private TextMeshProUGUI _timeRecharge;

        private ShipHolder _shipHolder;
        private IReadonlyShip _readonlyShip;
        private Laser _laser;
        private float _currentTime;
        
        [Inject]
        public void Construct(ShipHolder shipHolder)
        {
            _shipHolder = shipHolder;
        }

        public void Initialize()
        {
            _readonlyShip = _shipHolder.GetReadonlyShip();
            _laser = _shipHolder.GetLaser();
        }
        
        public void Run()
        {
            _laser.NumberChanged += OnNumberChanged;
            _laser.RechargeStarted += OnRechargeStarted;
            _readonlyShip.Died += OnShipDied;
            
            NumberLaserUpdate();
            TimeRechargeUpdate();
        }

        public void UpdateText()
        {
            _position.text = _readonlyShip.Position.ToString("F1");
            _speed.text = TEXT_SPEED + _readonlyShip.Speed;
            _rotation.text = TEXT_ROTATION + _readonlyShip.Rotation;
            
            ChangeTime();
        }
        
        private void OnNumberChanged() =>
            NumberLaserUpdate();
        
        private void OnRechargeStarted() =>
            _currentTime = _laser.TimeRecharge;
        
        private void OnShipDied()
        {
            _laser.NumberChanged -= OnNumberChanged;
            _laser.RechargeStarted -= OnRechargeStarted;
            _readonlyShip.Died -= OnShipDied;
        }
        
        private void NumberLaserUpdate() =>
            _numberLaser.text = TEXT_NUMBER_LASER + _laser.Number;
        
        private void TimeRechargeUpdate() =>
            _timeRecharge.text = TEXT_TIME_RECHARGE + _currentTime.ToString("F1");
        
        private void ChangeTime()
        {
            if (_currentTime > 0)
            {
                _currentTime -= Time.deltaTime;
                
                TimeRechargeUpdate();
            }
        }
    }
}