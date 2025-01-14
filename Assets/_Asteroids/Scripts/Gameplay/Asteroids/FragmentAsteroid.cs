using _Asteroids.Scripts.Configs;

namespace _Asteroids.Scripts.Gameplay.Asteroids
{
    public class FragmentAsteroid : AsteroidBase
    {
        private const string FRAGMENT_ASTEROID_CONFIG = "fragment_asteroid_config";

        private FragmentAsteroidConfig _config;

        private protected override void ApplyConfig()
        {
            _config = _configService.GetValue<FragmentAsteroidConfig>(FRAGMENT_ASTEROID_CONFIG);
            _speed = _config.Speed;
        }
    }
}