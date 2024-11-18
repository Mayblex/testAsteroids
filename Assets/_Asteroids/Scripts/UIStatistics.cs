using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

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
        [SerializeField] private Ship _ship;
        [SerializeField] private Laser _laser;

        private Rigidbody _shipRigidbody;
        private float _currentTime;

        private void Start()
        {
            _laser.NumberChanged += OnNumberChanged;
            _laser.RechargeStarted += OnRechargeStarted;
            _ship.Died += OnShipDied;

            _shipRigidbody = GameObject.FindWithTag("Ship").GetComponent<Rigidbody>();

            NumberLaserUpdate();
            TimeRechargeUpdate();
        }

        private void Update()
        {
            _position.text = _shipRigidbody.position.ToString("F1");
            _speed.text = TextSpeed + _shipRigidbody.linearVelocity.magnitude;
            //_canvasTextRotation.text = TextRotation + _shipRigidbody.angularVelocity.magnitude;
            _rotation.text = TextRotation + Mathf.Round(_shipRigidbody.transform.eulerAngles.z);

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
            _ship.Died -= OnShipDied;
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