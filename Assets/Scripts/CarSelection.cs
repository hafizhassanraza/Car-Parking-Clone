using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CarSelection : MonoBehaviour
{

    public GameObject[] characters;
    public Text Cash, Price;
    public int[] prices;
    public Image lockImg;
    public Button buyBtn, playbtn;
    public GameObject Left, Right, PricePnl, AlertPanel,Unlockcar;
    public int chIndex;
   
    
   
    AudioSource audioSource;
  
    
    public AudioClip audioClip;
    public Slider LoadingBar;
    public GameObject Loading;
    public void Awake()
    {
        
        
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); ;
        chIndex = 0;
        Price.text = prices[chIndex].ToString() + "$";
        Cash.text = PlayerPrefs.GetInt("Coins").ToString() + "$";
        PlayerPrefs.SetInt ("CarID", chIndex);
        Left.SetActive(false);
        playbtn.gameObject.GetComponent<Button>().interactable = true;
        lockImg.enabled = false;
        PricePnl.gameObject.SetActive(false);
        buyBtn.gameObject.SetActive(false);
        Unlockcar.gameObject.SetActive(false);
        







    }
   

    public void Next()
    {
        characters[chIndex].SetActive(false);
        chIndex++;
        characters[chIndex].SetActive(true);

        lockImg.enabled = true;
        
        Price.text = prices[chIndex].ToString() + "$";

        if (PlayerPrefs.GetInt("car" + chIndex) == 1)
        {
            PricePnl.gameObject.SetActive(false);
            playbtn.gameObject.GetComponent<Button>().interactable=true;
           
            buyBtn.gameObject.SetActive(false);
            Unlockcar.gameObject.SetActive(false);

            lockImg.enabled = false;
            PlayerPrefs.SetInt("CarID", chIndex);

        }
        else
        {
            playbtn.gameObject.GetComponent<Button>().interactable = false;


            PricePnl.gameObject.SetActive(true);
            buyBtn.gameObject.SetActive(true);
            Unlockcar.gameObject.SetActive(true);
            lockImg.enabled = true;
        }

        Right.SetActive(true);
        Left.SetActive(true);


        if (chIndex == characters.Length - 1)
        {
            Right.SetActive(false);

        }
        if (chIndex == 0)
        {
            PricePnl.gameObject.SetActive(false);
            lockImg.enabled = false;
            playbtn.gameObject.GetComponent<Button>().interactable = true;

            buyBtn.gameObject.SetActive(false);
            Unlockcar.gameObject.SetActive(false);

            PlayerPrefs.SetInt("CarID", chIndex);

        }
    }


    public void Previous()
    {
        characters[chIndex].SetActive(false);
        
        chIndex--;
        characters[chIndex].SetActive(true);
        lockImg.enabled = true;

        if (PlayerPrefs.GetInt("car" + chIndex) == 1)
        {
            PricePnl.gameObject.SetActive(false);
            buyBtn.gameObject.SetActive(false);
            Unlockcar.gameObject.SetActive(false);

            lockImg.enabled = false;
                     playbtn.gameObject.GetComponent<Button>().interactable=true;

            PlayerPrefs.SetInt("CarID", chIndex);

        }

        else
        {
            playbtn.gameObject.GetComponent<Button>().interactable = false;

            PricePnl.gameObject.SetActive(true);
            lockImg.enabled = true;
            buyBtn.gameObject.SetActive(true);
            Unlockcar.gameObject.SetActive(true);
        }


        Price.text = prices[chIndex].ToString() + "$";
        Left.SetActive(true);
        Right.SetActive(true);

        if (chIndex == 0)
        {
            Left.gameObject.SetActive(false);
            PricePnl.gameObject.SetActive(false);
            playbtn.gameObject.GetComponent<Button>().interactable = true;
            lockImg.enabled = false;
            buyBtn.gameObject.SetActive(false);
            Unlockcar.gameObject.SetActive(false);

            PlayerPrefs.SetInt("CarID", chIndex);
        }
    }
    public void Buy()
    {
        if (prices[chIndex] <= PlayerPrefs.GetInt("Coins"))
        {

            PricePnl.gameObject.SetActive(false);
            buyBtn.gameObject.SetActive(false);
            Unlockcar.gameObject.SetActive(false);
    

            lockImg.enabled = false;
            playbtn.gameObject.GetComponent<Button>().interactable = true;

            int cash = PlayerPrefs.GetInt("Coins");
            cash -= prices[chIndex];
            PlayerPrefs.SetInt("Coins",cash);
            PlayerPrefs.SetInt("CarID", chIndex);
            PlayerPrefs.SetInt("car" + chIndex, 1);
            Cash.text = PlayerPrefs.GetInt("Coins").ToString() + "$";

        
            // SelectCatEvent();
        }
        else
        {

            StartCoroutine(ShowAlertPanel());
        }
    }
    public void UnlockCar()
    {
        //Enter Your Unlock Car InApps Purchases code

            PricePnl.gameObject.SetActive(false);
            buyBtn.gameObject.SetActive(false);
            Unlockcar.gameObject.SetActive(false);
           lockImg.enabled = false;
            playbtn.gameObject.GetComponent<Button>().interactable = true;

            PlayerPrefs.SetInt("car" + chIndex, 1);
            

           
    
        
    }
        public void Select()
    {



        StartCoroutine(loadScene("LevelSelection"));


    }

    public void Back()
    {



        StartCoroutine(loadScene("MainMenu"));


    }
    IEnumerator ShowAlertPanel()
    {
        AlertPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        AlertPanel.SetActive(false);
    }

    IEnumerator loadScene(string sceneName)
    {
       
        Loading.SetActive(true);

        AsyncOperation sync = SceneManager.LoadSceneAsync(sceneName);
        while (!sync.isDone)
        {
            float progress = Mathf.Clamp01(sync.progress / 0.99f);
            LoadingBar.value = progress;

            yield return null;
        }
    }

}
