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
//          Edited by AliyerEdon in summer 2016
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for manage mobile input system

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarInput : MonoBehaviour
{
	[Header("Car Input Manager")]
	[Space(3)]
	// Main car controller handler
	public CarController carController;

	[Space(1)]
	// SteeringWheel handler
	public SteeringWheel SW;

	// Internal values for Throttle,Steer,Brake and ...
	[HideInInspector]public float SteerInput, ThrottleInput, BrakeInput, HandBrakeInput;

	// Is game started?
	bool started;

	[Space(1)]
	// Reverse sprites
	public Sprite ReverseSprite_D,ReverseSprite_R;

	[Space(1)]
	// Reverse button image
	public Image ReverseTarget;

	// Helper arrow handler for acitivate ans deActivate;
	[HideInInspector]public GameObject helperArrow;

	// Reversing alarm
	[HideInInspector]public AudioSource reverseAlarm;


	bool isReverseTemp;


	public GameObject arrowControlls,steeringWheelControll;
	int controllType = 0;

	// Accelerometer controlling
	Vector3 zeroAc;
	Vector3 curAc;
	public float accelSensibility  = 10f;
	public float accelSmooth = 0.5f;
	float GetAxisH = 0f;

	// Find player after car spawned
	IEnumerator Start ()
	{
		
		yield return new WaitForSeconds (.03f);
		helperArrow = GameObject.FindGameObjectWithTag ("Helper");
		helperArrow.SetActive (false);
		controllType = 0;
		if (PlayerPrefs.GetInt ("Controll") == 0) {
			arrowControlls.SetActive (true);
			steeringWheelControll.SetActive (false);
			controllType = 0;
		}
		if (PlayerPrefs.GetInt ("Controll") == 1) {
			arrowControlls.SetActive (false);
			steeringWheelControll.SetActive (true);
			controllType = 1;
		}
		if (PlayerPrefs.GetInt ("Controll") == 2) {
			arrowControlls.SetActive (false);
			steeringWheelControll.SetActive (false);
			controllType = 2;
		}
		// Delay for car spawn
		yield return new WaitForSeconds (.3f);



		// Find car by tag
		 carController = GameObject.FindGameObjectWithTag ("Player").GetComponent<CarController> ();

		// Game is now started
		started = true;

		reverseAlarm = carController.reverseAlram;
	}

	bool ReverseGear;

	void Update ()
	{
		if (started) {

			//Read steer input from StreengWheel component or keyborad
			#if !UNITY_EDITOR

			// Read accelerometer input    
			curAc = Vector3.Lerp(curAc, Input.acceleration-zeroAc, Time.deltaTime/accelSmooth);
			GetAxisH = Mathf.Clamp(curAc.x * accelSensibility, -1, 1);

			if(controllType == 1)
				SteerInput = SW.GetClampedValue ();

			if(controllType == 2)
				SteerInput = GetAxisH;


			#else
			SteerInput = Input.GetAxis("Horizontal");
			#endif


			// Send input values to CarController script
			carController.Move (SteerInput, ThrottleInput, BrakeInput, HandBrakeInput,isReverseTemp);

			if (Input.GetKey (KeyCode.E)) {
				Debug.Log ("SteerInput: " + SteerInput.ToString () + " ThrottleInput : " + ThrottleInput.ToString () +
				"BrakeInput: " + BrakeInput.ToString () + " HandBrakeInput : " + HandBrakeInput.ToString () +
				" isReverseTemp : " + isReverseTemp.ToString ());
			}
			// Keyboard controlling
			#if UNITY_EDITOR
			if (Input.GetKey (KeyCode.W))
				Throttle ();
			else
				ThrottleRalease ();

			if (Input.GetKey (KeyCode.S))
				Brake (true);
			else
				Brake (false);

			if (Input.GetKeyDown (KeyCode.C))
				GetComponent<CameraManager> ().NextCam ();

			if (Input.GetKeyDown (KeyCode.H))
				ToggleHelper ();

			if (Input.GetKeyDown (KeyCode.Escape))
				GetComponent<PauseMen> ().Pause ();
			#endif

		}

	}

	// This is for Throttle UI Button when pressed
	public void Throttle ()
	{
		if (!ReverseGear) 
		{

			ThrottleInput = 1f;
			BrakeInput = 0;
		} 
		else 
		{
			BrakeInput = -1f;


			isReverseTemp = true;

			if (reverseAlarm) {
				if (!reverseAlarm.isPlaying)
					reverseAlarm.Play ();
			}


		}
	}
	// This is for Throttle UI Button when released
	public void ThrottleRalease ()
	{


		ThrottleInput = 0;

		BrakeInput = 0;

		if(reverseAlarm)
		{
			if (reverseAlarm.isPlaying)
				reverseAlarm.Stop ();
		}

		isReverseTemp = false;

	}
	// This is for Throttle UI Button when pressed and released
	public void Brake (bool press)
	{
		if (press) {
			
			HandBrakeInput = 1f;

			// Light intensity controll
			carController.backLights [0].intensity = HandBrakeInput;
			carController.backLights [1].intensity = HandBrakeInput;
			carController.carBackLightMaterial.SetFloat ("_Intensity", .4343f);
		}

			if (!press) 
			{
				
		HandBrakeInput = 0;

				carController.backLights [0].intensity = 0;
				carController.backLights [1].intensity = 0;
				carController.carBackLightMaterial.SetFloat ("_Intensity", .1f);
				//carController.m_Topspeed = carController.m_TopspeedTemp; 


			}
		
	}
	// This is for HandBrake UI Button when pressed
	public void HandBrake (bool press)
	{
		if (press)
			HandBrakeInput = 1f;
		else
			HandBrakeInput = 0;
	}

	public void ToggleReverse()
	{
		ReverseGear = !ReverseGear;

		if (!ReverseGear)
			ReverseTarget.sprite = ReverseSprite_D;
		else
			ReverseTarget.sprite = ReverseSprite_R;
	}

	public void ToggleHelper()
	{
		helperArrow.SetActive (!helperArrow.activeSelf);
	}
	float velocityRef;
	public void Steer(bool left)
	{

		if (left)
			SteerInput = -1f;
		else
			SteerInput = 1f;    
	}

	public void SteerRelease()
	{
			SteerInput  =  0;
	}






	void ResetAxes(){
		zeroAc = Input.acceleration;
		curAc = Vector3.zero;
	}
   
}
