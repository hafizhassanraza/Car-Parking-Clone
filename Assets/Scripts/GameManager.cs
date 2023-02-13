using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public Slider Bar;
    public static GameManager Instance;
    public GameObject LevelFailPane, LevelWinPanel, PausePanel;
    public GameObject Loading;
    public Text Cash;
    public GameObject Env;
    public void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        //   PlayerPrefs.SetInt("Controll", 1);
        Cash.text = PlayerPrefs.GetInt("Coins").ToString() + "$";
        Env.SetActive(true);
        
    }
    public void SceneLoad(string SceneName){

        StartCoroutine(loadScene(SceneName));
}
    IEnumerator loadScene(string sceneName)
    {
        Time.timeScale = 1;
        Loading.SetActive(true);
        yield return new WaitForSeconds(2f);
        AsyncOperation sync = SceneManager.LoadSceneAsync(sceneName);
        while (!sync.isDone)
        {
            float progress = Mathf.Clamp01(sync.progress / 0.99f);
            Bar.value = progress;

            yield return null;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        StartCoroutine(loadScene("GamePlay"));

    }
     public void Next()
    {
        Time.timeScale = 1f;
        if (PlayerPrefs.GetInt("CarLevelID") < 39)
        {
            
            
           
            PlayerPrefs.SetInt("CarLevelID", PlayerPrefs.GetInt("CarLevelID") + 1);
        }
        if (PlayerPrefs.GetInt("CarLevelID") == 39)
        {



            PlayerPrefs.SetInt("CarLevelID", 5);
        }
        StartCoroutine(loadScene("GamePlay"));
    }

    public void Menu()
    {
        Time.timeScale = 1;
        StartCoroutine(loadScene("MainMenu"));
    }
    public void LevelComplete()
    {
        StartCoroutine(ActivityCompleted());

    }

   

    IEnumerator ActivityCompleted()
    {
        
        yield return new WaitForSeconds(2f);
        LevelWinPanel.SetActive(true);
        if (PlayerPrefs.GetInt("CarLevelID") < 39)
        {
        

            if (PlayerPrefs.GetInt("CarLevelID") == PlayerPrefs.GetInt("CarUnlockedLevel"))
            {
                
                PlayerPrefs.SetInt("CarUnlockedLevel", PlayerPrefs.GetInt("CarUnlockedLevel") + 1);

            }
            
        }
    }
}
