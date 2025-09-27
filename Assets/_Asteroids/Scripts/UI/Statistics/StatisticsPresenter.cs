using _Asteroids.Scripts.Gameplay.Ship;
using UnityEngine;

namespace _Asteroids.Scripts.UI.Statistics
{
    public class StatisticsPresenter
    {
        private StatisticsView _view;
        private ShipHolder _shipHolder;
        private IShip _ship;
        private Laser _laser;

        private float _currentTime;

        public StatisticsPresenter(StatisticsView view, ShipHolder shipHolder)
        {
            _view = view;
            _shipHolder = shipHolder;
        }

        public void Initialize()
        {
            _ship = _shipHolder.GetShip();
            _laser = _shipHolder.GetLaser();
            
            _laser.NumberChanged += OnNumberChanged;
            _laser.RechargeStarted += OnRechargeStarted;
            _ship.Died += OnShipDied;
            
            UpdateNumberLaser(); 
            UpdateTimeRecharge();
        }

        public void UpdateText()
        {
            _view.SetPosition(_ship.Position.ToString("F1")); 
            _view.SetSpeed(_ship.Speed.ToString()); 
            _view.SetRotation(_ship.Rotation.ToString());
            
            ChangeTime();
        }
        
        private void OnNumberChanged() => 
            UpdateNumberLaser();
        
        private void OnRechargeStarted() => 
            _currentTime = _laser.TimeRecharge;
        
        private void OnShipDied()
        {
            _laser.NumberChanged -= OnNumberChanged;
            _laser.RechargeStarted -= OnRechargeStarted;
            _ship.Died -= OnShipDied;
        }
        
        private void UpdateNumberLaser() => 
            _view.SetNumberLaser(_laser.Number.ToString());
        
        private void UpdateTimeRecharge() => 
            _view.SetTimeRecharge(_currentTime.ToString("F1"));
        
        private void ChangeTime()
        {
            if (_currentTime > 0)
            {
                _currentTime -= Time.deltaTime;
                
                UpdateTimeRecharge();
            }
        }
    }
}