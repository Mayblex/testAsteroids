using Zenject;

namespace _Asteroids.Scripts.Services
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ZenjectSceneLoader _sceneLoader;
        
        public void LoadGame()
        {
            _sceneLoader.LoadScene("MainScene");
        }
    }
}