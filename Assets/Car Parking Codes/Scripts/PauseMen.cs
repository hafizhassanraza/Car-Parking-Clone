/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

//--------------------------------------------------------------
//
//                    Car Parking Kit
//          Writed by AliyerEdon in summer 2016
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for level Pause menu system   

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMen : MonoBehaviour
{
	[Header("Pause Menu Manager")]


	public GameObject PauseMenu;
	public Text LoadingText, AllScore;

	public string garageName  = "Garage Bus";

	public void Pause ()
	{
		PauseMenu.SetActive (true);
		AllScore.text = "Total Score is :   "+PlayerPrefs.GetInt ("Coins").ToString ();
		Time.timeScale = 0f;
	}

	public void Resume ()
	{
		PauseMenu.SetActive (false);
		Time.timeScale = 1f;
	}



	public void Retry ()
	{
		LoadingText.text = "Please Wait...";
		PauseMenu.SetActive (false);
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);


	}

	public void Exit ()
	{
		Time.timeScale = 1f;
		LoadingText.text = "Please Wait...";
		SceneManager.LoadScene(garageName);
	}
}
