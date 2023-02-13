using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMainMenu : MonoBehaviour
{
    public GameObject loading;
    public Slider Bar;
    public Text Cash;

    private AsyncOperation asynLoading;
    

    void Start()
    {
        Cash.text = PlayerPrefs.GetInt("Coins").ToString() + "$";
        // Invoke("Animation_On",2f);
    }

   

   


    public void Play()
    {


        StartCoroutine(loadScene("CarSelection"));



    }


    public void MoreGames()
    {

        Application.OpenURL(" Add your URL here");
    }


    public void RateUs()
    {

        Application.OpenURL(" Add Your URl Here");

    }

    public void privacypolicy()
    {
        Application.OpenURL(" Add your URl here");
    }

    IEnumerator loadScene(string sceneName)
    {
        loading.SetActive(true);
        yield return new WaitForSeconds(2f);
        AsyncOperation sync = SceneManager.LoadSceneAsync(sceneName);
        while (!sync.isDone)
        {
            float progress = Mathf.Clamp01(sync.progress / 0.99f);
            Bar.value = progress;
            yield return null;
        }
    }


    //void callAd()
    //{
    //    if (calladsOnce)
    //    {
    //        calladsOnce = false;
    //        if (PlayerPrefs.GetInt("isAdsoff") == 0)
    //        {
    //            //				AdsHandler.Instance.LoadAd ();
    //        }
    //    }
    //}


    public void RemoveAdds()
    {
        //Remove Adds Code Here
    }
    public void UnlockAllLevels()
    {
        //Unlock all Levels Code
        PlayerPrefs.SetInt("CarUnlockedLevel", 39);

    }
    public void UnlockAllCars()
    {
        //Unlock all Cars Code
        for (int i=1;i<5; i++) { 
        PlayerPrefs.SetInt("car" + i, 1);
        }
    }
    public void GetCoins(int coins)
    {
        //Add new Amount Of Coins Via Parameter Code
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins")+coins);
        Cash.text = PlayerPrefs.GetInt("Coins").ToString() + "$";
    }
    public void UnlockEverything(int coins)
    {
        //Add new Amount Of Coins Via Parameter Code
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coins);
        Cash.text = PlayerPrefs.GetInt("Coins").ToString() + "$";
        //Unlock all Cars Code
        for (int i = 1; i < 5; i++)
        {
            PlayerPrefs.SetInt("car" + i, 1);
        }
        //Unlock all Levels Code
        PlayerPrefs.SetInt("CarUnlockedLevel", 39);

        //Remove Adds Code Here

    }







}
