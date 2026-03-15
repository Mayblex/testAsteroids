using UnityEngine;

namespace _Asteroids.Scripts.Services.Assets
{
    [CreateAssetMenu(menuName = "Assets/Asset Catalog", fileName = "AssetCatalog")]
    public class AssetCatalogSO: ScriptableObject
    {
        public string[] GameplayWarpup;

        public string ShipPrefab;
        public string AsteroidPrefab;
        public string FragmentAsteroidPrefab;
        public string UFOPrefab;
        public string BulletPrefab;
        public string UIStatisticsPrefab;
        public string WindowGameOverPrefab;
    }
}