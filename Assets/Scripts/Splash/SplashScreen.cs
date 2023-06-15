using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private int gameSceneIndex;
    
    void Start()
    {
        StartCoroutine(LoadGameScene(gameSceneIndex));
    }

    IEnumerator LoadGameScene(int sceneIndex)
    {
        var asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
