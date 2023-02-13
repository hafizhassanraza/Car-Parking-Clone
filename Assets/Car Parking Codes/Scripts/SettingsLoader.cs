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

// This script used for load game settings
using UnityEngine;
using System.Collections;

public class SettingsLoader : MonoBehaviour {


	public AudioSource AmbiantSound;

	public MeshRenderer Sea;


	[Header("Drag This For Amplify Color")]
	[Header("You need edit script for Amplify Color support")]
	[Space(3)]
	public Camera mainCamera;

	void Start () {
		if (PlayerPrefs.GetInt ("AmbientSound") == 3)
			AmbiantSound.Play ();
		else
			AmbiantSound.Stop ();

		if (PlayerPrefs.GetInt ("Sea") != 3)
			Sea.material.shader = Shader.Find ("Mobile/Diffuse");




		// Amplify color integeration
		/*
		if (!mainCamera)
			mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		
		if (PlayerPrefs.GetInt ("amplifyColor") != 3)
			mainCamera.GetComponent<AmplifyColorEffect> ().enabled = false;
		else
			mainCamera.GetComponent<AmplifyColorEffect> ().enabled = true;*/
	
	
	}
}
