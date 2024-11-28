using TMPro;
using UnityEngine;

namespace Scripts
{
    public class UIStatistics : MonoBehaviour
    {
        private const string TextSpeed = "Speed: ";
        private const string TextRotation = "Rotation: ";
        private const string TextNumberLaser = "Laser: ";
        private const string TextTimeRecharge = "Time: ";

        [SerializeField] private TextMeshProUGUI _position;
        [SerializeField] private TextMeshProUGUI _speed;
        [SerializeField] private TextMeshProUGUI _rotation;
        [SerializeField] private TextMeshProUGUI _numberLaser;
        [SerializeField] private TextMeshProUGUI _timeRecharge;
        
        private IReadonlyShip _readonlyShip;
        private Laser _laser;
        private float _currentTime;
        
        public void Constract(IReadonlyShip readonlyShip, Laser laser)
        {
            _readonlyShip = readonlyShip;
            _laser = laser;
        }
        
        public void Run()
        {
            _laser.NumberChanged += OnNumberChanged;
            _laser.RechargeStarted += OnRechargeStarted;
            _readonlyShip.Died += OnShipDied;
            
            NumberLaserUpdate();
            TimeRechargeUpdate();
        }

        private void Update()
        {
            _position.text = _readonlyShip.Position.ToString("F1");
            _speed.text = TextSpeed + _readonlyShip.Speed;
            _rotation.text = TextRotation + _readonlyShip.Rotation;

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
            _numberLaser.text = TextNumberLaser + _laser.Number;

        private void TimeRechargeUpdate() =>
            _timeRecharge.text = TextTimeRecharge + _currentTime.ToString("F1");

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