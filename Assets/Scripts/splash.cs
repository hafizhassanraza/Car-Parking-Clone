using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class splash : MonoBehaviour
{

    public Slider Bar;

    void Start()
    {
        if (PlayerPrefs.GetInt("FirstRun") != 3)
        {
            PlayerPrefs.SetInt("FirstRun", 3);
            PlayerPrefs.SetInt("Coins", 500);
        }
    
        StartCoroutine(loadScene("MainMenu"));
    }

    IEnumerator loadScene(string sceneName)
    {
        yield return new WaitForSeconds(2f);
        AsyncOperation sync = SceneManager.LoadSceneAsync(sceneName);
        while (!sync.isDone)
        {
            float progress = Mathf.Clamp01(sync.progress / 0.99f);
            Bar.value = progress;

            yield return null;
        }
    }
}
