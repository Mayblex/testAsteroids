using System.Threading.Tasks;
using Firebase;
using Firebase.Extensions;
using UnityEngine;

namespace _Asteroids.Scripts.Services
{
    public class FirebaseInitialize
    {
        public async Task InitializeFirebase()
        {
            await FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    FirebaseApp app = FirebaseApp.DefaultInstance;
                    Debug.Log("Firebase initialized successfully.");
                }
                else
                {
                    Debug.LogError("Firebase initialization failed: " + task.Exception);
                }
            });
        }
    }
}