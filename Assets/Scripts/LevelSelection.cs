using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{

    public Transform levels;
    public GameObject loading;
    public Slider sliderBar;
    //public GameObject unlockbutton;
   


   
    void Start()
    {
        
        for (int i = 0; i <= PlayerPrefs.GetInt("CarUnlockedLevel"); i++)
        {
            print(i);
            levels.GetChild(i).GetComponent<Button>().interactable = true;
            levels.GetChild(i).GetChild(1).gameObject.SetActive(false);
        }
       
    }


   



    public void PlayLvl(int lvl)
    {
        PlayerPrefs.SetInt("CarLevelID",lvl);

        StartCoroutine(loadScene("GamePlay"));

    }
    IEnumerator loadScene(string sceneName)
    {
        loading.SetActive(true);
        yield return new WaitForSeconds(2f);
        AsyncOperation sync = SceneManager.LoadSceneAsync(sceneName);
        while (!sync.isDone)
        {
            float progress = Mathf.Clamp01(sync.progress / 2f);
            sliderBar.value = progress;
            yield return null;
        }
    }
    public void Back()
    {



        StartCoroutine(loadScene("CarSelection"));


    }
}
