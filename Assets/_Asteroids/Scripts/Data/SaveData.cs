using System;

namespace _Asteroids.Scripts.Data
{
    [Serializable]
    public class SaveData
    {
        public int BestScore;
        public bool NoAdsPurchased;
        public long SaveAtUnix;
    }
}