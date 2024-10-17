using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Splash
{
    public class SplashEntryPoint : MonoBehaviour
    {
        [SerializeField] private int gameSceneIndex;

        private void Start()
        {
            LoadGameScene(gameSceneIndex);
        }

        private async void LoadGameScene(int sceneIndex)
        {
            Debug.Log("Start loading scene");
            var asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
            await UniTask.WaitWhile(() => asyncLoad.isDone);
            Debug.Log("Scene is already loaded!");
        }
    }
}