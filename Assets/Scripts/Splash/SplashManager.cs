using Game.Services.SceneLoading;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SplashManager : IInitializable
{
    // [SerializeField] private string gameSceneName;
    //
    // void Start()
    // {
    //     StartCoroutine(LoadGameScene(gameSceneName));
    // }
    //
    public void Initialize()
    {
        LoadGameFromSplash();
    }
    
    private void LoadGameFromSplash()
    {
        var sceneLoadingAsync = SceneManager.LoadSceneAsync(SceneNames.GAME);
        sceneLoadingAsync.completed += _ =>
        {
            Debug.Log("Game scene loaded!");
        };
    }
}
