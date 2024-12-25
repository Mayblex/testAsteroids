namespace _Asteroids.Scripts.Services
{
    public class GameplayStatistics
    {
        public int BulletShots { get; private set; }
        public int LaserShots { get; private set; }
        public int DestroyedAsteroids { get; private set; }
        public int DestroyedUFOs { get; private set; }

        public void IncrementRegularShots() => BulletShots++;
        public void IncrementLaserShots() => LaserShots++;
        public void IncrementDestroyedAsteroids() => DestroyedAsteroids++;
        public void IncrementDestroyedUFOs() => DestroyedUFOs++;
    }
}