using Services;
using UnityEngine;

namespace System
{
    public class Bootstrapper : MonoBehaviour
    {
        private Hud _hud;

        private void Awake()
        {
            Services();
        }

        private async void Services()
        {
            var hud = new Hud();
            await hud.Init();
        
            Debug.Log("All services are initialized");
        }
    }
}
