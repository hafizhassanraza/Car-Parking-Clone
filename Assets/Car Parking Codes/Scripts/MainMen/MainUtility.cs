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

// This script used for main utilities used in game menus

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUtility : MonoBehaviour
{
	
	public GameObject Loading;

	public GameObject MainMenuOBJ, CarSelectOBJ;

	public int startingScore = 1400;

	// Main Menu screen resolution
	public int xx = 1280,yy = 720;

	void Awake ()
	{
		Screen.SetResolution (xx, yy, true);

		Camera.main.aspect = 16f / 9f;


		// Is game first run?   3 => true    0 => false
		if (PlayerPrefs.GetInt ("FirstRun") != 3) 
		{
			PlayerPrefs.SetInt ("FirstRun", 3);

			// Open first level
			PlayerPrefs.SetInt ("CarLevelNum", 1);
			PlayerPrefs.SetInt ("BusLevelNum", 1);
			PlayerPrefs.SetInt ("TruckLevelNum", 1);

			// Set ambiant sound in settings true
			PlayerPrefs.SetInt ("AmbientSound", 3);

			// Set Sea active in settings true
			PlayerPrefs.SetInt ("Sea", 3);

			// Open first car
			PlayerPrefs.SetInt ("Car0", 3);
			PlayerPrefs.SetInt ("Bus0", 3);
			PlayerPrefs.SetInt ("Truck0", 3);


			// Player starting first time coins
			PlayerPrefs.SetInt ("Coins", startingScore);
		}
	}

	void Update ()
	{


		if (Input.GetKeyDown (KeyCode.H)) {
			PlayerPrefs.DeleteAll ();
			Debug.Log ("PlayerPrefs.DeleteAll ();");
		}
		if (Input.GetKeyDown (KeyCode.E))
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 14000);
	}

	public void Exit ()
	{
		Application.Quit ();
	}

	public void SetTrue (GameObject target)
	{
		target.SetActive (true);
	}

	public void SetFalse (GameObject target)
	{
		target.SetActive (false);
	}

	public void ToggleObject (GameObject target)
	{
		target.SetActive (!target.activeSelf);
	}

	public void LoadLevel (string name)
	{

		Loading.SetActive (true);
		SceneManager.LoadScene (name);
	}

	public void OpenURL (string val)
	{
		Application.OpenURL (val);
	}
}
