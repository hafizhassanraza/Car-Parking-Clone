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

// This script used for game settings menu

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{

	// Use this for initialization
	public Toggle AmbientSound, Sea,amplifyColor;

	// States info text
	public Text resolutionState,qualityState;


	void Start ()
	{

		// Read starting setting values
		if (PlayerPrefs.GetInt ("AmbientSound") == 3)
			AmbientSound.isOn = true;
		else
			AmbientSound.isOn = false;
		
		if (PlayerPrefs.GetInt ("Sea") == 3)
			Sea.isOn = true;
		else
			Sea.isOn = false;


		if (PlayerPrefs.GetInt ("amplifyColor") == 3)
			amplifyColor.isOn = true;
		else
			amplifyColor.isOn = false;
		

		if (PlayerPrefs.GetInt ("Quality") == 0)
			qualityState.text = "Fastest";
		if (PlayerPrefs.GetInt ("Quality") == 3)
			qualityState.text = "Good";
		if (PlayerPrefs.GetInt ("Quality") == 5)
			qualityState.text = "Fantastic";

		if (PlayerPrefs.GetInt ("Resolution") == 0) {
			PlayerPrefs.SetInt ("Resolution", 720);
			resolutionState.text = "720P";
		} else {
			if (PlayerPrefs.GetInt ("Resolution") == 506)
				resolutionState.text = "506";
			if (PlayerPrefs.GetInt ("Resolution") == 720)
				resolutionState.text = "720P";
			if (PlayerPrefs.GetInt ("Resolution") == 1080)
				resolutionState.text = "1080P";
		}
	}

	
	// Public function for ambient sound toggle
	public void Set_AmbientSound ()
	{
		StartCoroutine (AmbiantSound_Save ());
	}

	public void Set_Sea ()
	{
		StartCoroutine (Sea_Save ());
	}


	public void amplifyColor_Sea ()
	{
		StartCoroutine (amplifyColor_Save ());
	}
	public void SetQualityLevel (int id)
	{
		PlayerPrefs.SetInt ("Quality", id);
		QualitySettings.SetQualityLevel (id, false);

		if (id == 0)
			qualityState.text = "Fastest";
		if (id == 3)
			qualityState.text = "Good";
		if (id == 5)
			qualityState.text = "Fantastic";
	}


	public void SetResolution (int id)
	{
		PlayerPrefs.SetInt ("Resolution", id);

		if (id == 506)
			resolutionState.text = "506";
		if (id == 720)
			resolutionState.text = "720P";
		if (id == 1080)
			resolutionState.text = "1080P";
	}
	IEnumerator AmbiantSound_Save ()
	{
		yield return new WaitForSeconds (.3f);
		if (AmbientSound.isOn)
			PlayerPrefs.SetInt ("AmbientSound", 3);  //3 = true;
		else
			PlayerPrefs.SetInt ("AmbientSound", 0);//0 = false;
	}
	IEnumerator amplifyColor_Save ()
	{
		yield return new WaitForSeconds (.3f);
		if (amplifyColor.isOn)
			PlayerPrefs.SetInt ("amplifyColor", 3);  //3 = true;
		else
			PlayerPrefs.SetInt ("amplifyColor", 0);//0 = false;
	}


	IEnumerator Sea_Save ()
	{
		yield return new WaitForSeconds (.3f);
		if (Sea.isOn)
			PlayerPrefs.SetInt ("Sea", 3);  //3 = true;
		else
			PlayerPrefs.SetInt ("Sea", 0);//0 = false;
	}





}
