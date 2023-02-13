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
//          Edited by AliyerEdon in summer 2016  -  All rights reserved - Orginally from Unity Standard Assets car demo
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for main car behaviour

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CarDriveType
{
	FrontWheelDrive,
	RearWheelDrive,
	FourWheelDrive
}

public enum SpeedType
{
	MPH,
	KPH
}

public class CarController : MonoBehaviour
{

	public bool canControll = true;

	public CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;

	public WheelCollider[] Wheel_Colliders = new WheelCollider[4];

	 public GameObject[] Wheel_Transforms = new GameObject[4];

	public Transform CentreOfMass;

	 private float MaximumSteerAngle;

	public float MaxSteerInput = 25f;

	[Range (0, 1)] [SerializeField] private float m_SteerHelper;

	// 0 is raw physics , 1 the car will grip in the direction it is facing

	public float EngineTorque = 1400f;
	public float ReverseTorque = 140f;
	public float HandbrakeTorque = 140f;
	public float m_Downforce = 100f;
	public SpeedType m_SpeedType;
	public float m_Topspeed = 200;
	public static int NoOfGears = 5;
	public float GearShiftDelay = 0.3f;

	[HideInInspector] float m_RevRangeBoundary = 1f;
	public float m_SlipLimit;
	public float m_BrakeTorque;
	[HideInInspector]public float m_TopspeedTemp;
	private Quaternion[] m_WheelMeshLocalRotations;
	private Vector3 m_Prevpos, m_Pos;
	private float m_SteerAngle;
	public int m_GearNum;
	private float m_GearFactor;
	private float m_OldRotation;
	private float m_CurrentTorque;
	private Rigidbody m_Rigidbody;
	private const float k_ReversingThreshold = 0.01f;

	public bool Skidding { get; private set; }

	public float BrakeInput { get; private set; }

	public float CurrentSteerAngle{ get { return m_SteerAngle; } }

	public float CurrentSpeed{ get { return m_Rigidbody.velocity.magnitude * 2.23693629f; } }

	public float MaxSpeed{ get { return m_Topspeed; } }

	public float Revs { get; private set; }

	public float AccelInput { get; private set; }



	// car lights
	public Light[] backLights;


	// Car BackLight material (self-Illuminated)
	public Material carBackLightMaterial;


	// DashBoard steeringwheel tranform
	public Transform SteeringWheelTransform;

	public float[] gearRatio;

	void Update ()
	{

		if (SteeringWheelTransform)
			SteeringWheelTransform.rotation = 
				transform.rotation * Quaternion.Euler (0,   0,(Wheel_Colliders[0].steerAngle ) * -6 );


		WheelAlign ();


	}
	public Animator anim;

	// Use this for initialization
	public string GarageSceneName = "Garage_";


	public GameObject helper, nightLights;
	// Reversing alarm handler
	[HideInInspector]public AudioSource reverseAlram;


	void OnDrawGizmos()
	{

		Gizmos.color = Color.red;

		Gizmos.DrawSphere (CentreOfMass.localPosition, 0.1f);

	}



	private void Start ()
	{

		if(PlayerPrefs.GetInt("NightMode")==3) // 3=>true,    0=>false;
			nightLights.SetActive (true);
		else
			nightLights.SetActive (false);
		
		audioCar = GetComponent<CarAudio> ();

		if (audioCar.reverseAlarm)
			reverseAlram = audioCar.reverseAlarm;
		else {
		
			if(SceneManager.GetActiveScene().name.Contains("Bus"))
				Debug.Log ("Please add reverse alarm audio source on CarAudio component");

		}


		// Destroy car controller and audio when it is spawned in car garage
		if (SceneManager.GetActiveScene ().name.Contains ("Garage")) {

			canControll = false;

			GetComponent<CarAudio> ().enabled = false;


			if(anim)
				anim.CrossFade ("Null", 0.0003f);

			helper.SetActive (false);
			nightLights.SetActive (false);

		} else {
			if (SceneManager.GetActiveScene ().name == GarageSceneName) {
				GetComponent<CarAudio> ().enabled = false;

				if(anim)
					anim.CrossFade ("Null", 0.0003f);

				helper.SetActive (false);
				nightLights.SetActive (false);


			}
		}



		
			m_TopspeedTemp = m_Topspeed;

		m_WheelMeshLocalRotations = new Quaternion[4];

		for (int i = 0; i < 4; i++) 
		{ 
			m_WheelMeshLocalRotations [i] = Wheel_Transforms [i].transform.localRotation;
		}

		Wheel_Colliders [0].attachedRigidbody.centerOfMass = Vector3.zero;

		GetComponent<Rigidbody> ().centerOfMass = CentreOfMass.localPosition;


		HandbrakeTorque = float.MaxValue;

		m_Rigidbody = GetComponent<Rigidbody> ();

		m_CurrentTorque = EngineTorque;

		StartCoroutine (GearChanging ());
	}

	[HideInInspector]public bool Reversng;

	CarAudio audioCar;

	IEnumerator GearChanging ()
	{
		while (true) 
		{
			yield return new WaitForSeconds (0.3f);
			if (!Reversng) {
				float f = Mathf.Abs (CurrentSpeed / MaxSpeed);
				float upgearlimit = (1 / (float)NoOfGears) * (m_GearNum + 1);
				float downgearlimit = (1 / (float)NoOfGears) * m_GearNum;


				if (m_GearNum > 0 && f < downgearlimit)
				{
					audioCar.audioSource.volume = 0.7f;
					yield return new WaitForSeconds (0);
					audioCar.audioSource.volume = 1f;
					m_GearNum--;
				}

				if (f > upgearlimit && (m_GearNum < (NoOfGears - 1)))
				{
					audioCar.audioSource.volume = 0.3f;
					if(anim)
						anim.SetBool ("Gear", true);
					yield return new WaitForSeconds (GearShiftDelay);
					audioCar.audioSource.volume = 1f;
					if(anim)
						anim.SetBool ("Gear", false);
					m_GearNum++;





				}
			}
		}
	}


	// simple function to add a curved bias towards 1 for a value in the 0-1 range
	private static float CurveFactor (float factor)
	{
		return 1 - (1 - factor) * (1 - factor);
	}


	// unclamped version of Lerp, to allow value to exceed the from-to range
	private static float ULerp (float from, float to, float value)
	{
		return (1.0f - value) * from + value * to;
	}


	private void CalculateGearFactor ()
	{
		float f = (1 / (float)NoOfGears);
		// gear factor is a normalised representation of the current speed within the current gear's range of speeds.
		// We smooth towards the 'target' gear factor, so that revs don't instantly snap up or down when changing gear.
		var targetGearFactor = Mathf.InverseLerp (f * m_GearNum, f * (m_GearNum + 1), Mathf.Abs (CurrentSpeed / MaxSpeed));
		m_GearFactor = Mathf.Lerp (m_GearFactor, targetGearFactor, Time.deltaTime * 5f);
	}


	private void CalculateRevs ()
	{
		// calculate engine revs (for display / sound)
		// (this is done in retrospect - revs are not used in force/power calculations)
		CalculateGearFactor ();
		var gearNumFactor = m_GearNum / (float)NoOfGears;
		var revsRangeMin = ULerp (0f, m_RevRangeBoundary, CurveFactor (gearNumFactor));
		var revsRangeMax = ULerp (m_RevRangeBoundary, 1f, gearNumFactor);
		Revs = ULerp (revsRangeMin, revsRangeMax, m_GearFactor);
	}


	void WheelAlign()
	{

		for (int i = 0; i < 4; i++) {
			Quaternion quat;
			Vector3 position;
			Wheel_Colliders [i].GetWorldPose (out position, out quat);
			Wheel_Transforms [i].transform.position = position;
			Wheel_Transforms [i].transform.rotation = quat;
		}
	}
	public void Move (float steering, float accel, float footbrake, float handbrake,bool isReverse)
	{
		


			//clamp input values

		if (canControll) {
			steering = Mathf.Clamp (steering, -1, 1);

	
			AccelInput = accel = Mathf.Clamp (accel, 0, 1);


			if (footbrake != 0)
				BrakeInput = footbrake = -1 * Mathf.Clamp (footbrake, -1, 0);
			else
				BrakeInput = 0;






			/*Debug.Log ("steering  " + steering.ToString () + "  =>  "
		+ "AccelInput  " + AccelInput.ToString () + "  =>  "
		+ "BrakeInput  " + BrakeInput.ToString () + "  =>  " + "handbrake  " + handbrake.ToString ());*/
			handbrake = Mathf.Clamp (handbrake, 0, 1);

			// Steer angle limiter
			MaximumSteerAngle = MaxSteerInput - (CurrentSpeed / 3);

			if (m_SteerAngle > MaximumSteerAngle)
				m_SteerAngle = MaximumSteerAngle;
			m_SteerAngle = steering * MaximumSteerAngle;
			Wheel_Colliders [0].steerAngle = m_SteerAngle;
			Wheel_Colliders [1].steerAngle = m_SteerAngle;

			SteerHelper ();
			ApplyDrive (accel, footbrake, isReverse);
			CapSpeed ();

			//Set the handbrake.
			//Assuming that wheels 2 and 3 are the rear wheels.

			if (handbrake > 0f) {
				var hbTorque = handbrake * HandbrakeTorque;

				Wheel_Colliders [2].brakeTorque = hbTorque;
				Wheel_Colliders [3].brakeTorque = hbTorque;
				;
			}


			CalculateRevs ();


			//GearChanging ();

			AddDownForce ();
			CheckForWheelSpin ();
			TractionControl ();


		} else {


			Wheel_Colliders [0].motorTorque = 0;
			Wheel_Colliders [1].motorTorque = 0;
			Wheel_Colliders [2].motorTorque = 0;
			Wheel_Colliders [3].motorTorque = 0;

			Wheel_Colliders [0].brakeTorque = 10000f;
			Wheel_Colliders [1].brakeTorque = 10000f;
			Wheel_Colliders [2].brakeTorque = 10000f;
			Wheel_Colliders [3].brakeTorque = 10000f;
		}
	}


	private void CapSpeed ()
	{
		float speed = m_Rigidbody.velocity.magnitude;
		switch (m_SpeedType) {
		case SpeedType.MPH:

			speed *= 2.23693629f;
			if (speed > m_Topspeed)
				m_Rigidbody.velocity = (m_Topspeed / 2.23693629f) * m_Rigidbody.velocity.normalized;
			break;

		case SpeedType.KPH:
			speed *= 3.6f;
			if (speed > m_Topspeed)
				m_Rigidbody.velocity = (m_Topspeed / 3.6f) * m_Rigidbody.velocity.normalized;
			break;
		}
	}


	private void ApplyDrive (float accel, float footbrake,bool isReverse)
	{

		float thrustTorque;
		switch (m_CarDriveType) {
		case CarDriveType.FourWheelDrive:
			thrustTorque = accel * (m_CurrentTorque / 4f);
			for (int i = 0; i < 4; i++) {
				Wheel_Colliders [i].motorTorque = thrustTorque *gearRatio[m_GearNum];
			}
			break;

		case CarDriveType.FrontWheelDrive:
			thrustTorque = accel * (m_CurrentTorque / 2f);
			Wheel_Colliders [0].motorTorque = Wheel_Colliders [1].motorTorque = thrustTorque*gearRatio[m_GearNum];
			break;

		case CarDriveType.RearWheelDrive:
			thrustTorque = accel * (m_CurrentTorque / 2f);

			Wheel_Colliders [2].motorTorque = Wheel_Colliders [3].motorTorque = thrustTorque*gearRatio[m_GearNum];
			break;

		}

		for (int i = 0; i < 4; i++) {
			/*if (CurrentSpeed > 0 && Vector3.Angle (transform.forward, m_Rigidbody.velocity) < 50f) {


				
			
			}*/

			
			if (footbrake > 0) {
				Wheel_Colliders [i].brakeTorque = 0f;

				Wheel_Colliders [i].motorTorque = -ReverseTorque * footbrake;
			
			} else {
				if(accel==0)
					Wheel_Colliders [i].motorTorque = 0;
				
				Wheel_Colliders [i].brakeTorque = m_BrakeTorque*footbrake;
			}

			/*if (CurrentSpeed < 5 ) 
				Wheel_Colliders [i].brakeTorque = 0;
			*/

		}
	}


	private void SteerHelper ()
	{
		for (int i = 0; i < 4; i++) {
			WheelHit wheelhit;
			Wheel_Colliders [i].GetGroundHit (out wheelhit);
			if (wheelhit.normal == Vector3.zero)
				return; // wheels arent on the ground so dont realign the rigidbody velocity
		}

		// this if is needed to avoid gimbal lock problems that will make the car suddenly shift direction
		if (Mathf.Abs (m_OldRotation - transform.eulerAngles.y) < 10f) {
			var turnadjust = (transform.eulerAngles.y - m_OldRotation) * m_SteerHelper;
			Quaternion velRotation = Quaternion.AngleAxis (turnadjust, Vector3.up);
			m_Rigidbody.velocity = velRotation * m_Rigidbody.velocity;
		}
		m_OldRotation = transform.eulerAngles.y;
	}


	// this is used to add more grip in relation to speed
	private void AddDownForce ()
	{
		Wheel_Colliders [0].attachedRigidbody.AddForce (-transform.up * m_Downforce *
		Wheel_Colliders [0].attachedRigidbody.velocity.magnitude);
	}


	// checks if the wheels are spinning and is so does three things
	// 1) emits particles
	// 2) plays tiure skidding sounds
	// 3) leaves skidmarks on the ground
	// these effects are controlled through the WheelEffects class
	private void CheckForWheelSpin ()
	{
		// loop through all wheels
		for (int i = 0; i < 4; i++) {
			WheelHit wheelHit;
			Wheel_Colliders [i].GetGroundHit (out wheelHit);
		}
	}

	// crude traction control that reduces the power to wheel if the car is wheel spinning too much
	private void TractionControl ()
	{
		WheelHit wheelHit;
		switch (m_CarDriveType) {
		case CarDriveType.FourWheelDrive:
                    // loop through all wheels
			for (int i = 0; i < 4; i++) {
				Wheel_Colliders [i].GetGroundHit (out wheelHit);

				AdjustTorque (wheelHit.forwardSlip);


			}
			break;

		case CarDriveType.RearWheelDrive:
			Wheel_Colliders [2].GetGroundHit (out wheelHit);
			AdjustTorque (wheelHit.forwardSlip);

			Wheel_Colliders [3].GetGroundHit (out wheelHit);
			AdjustTorque (wheelHit.forwardSlip);
			break;

		case CarDriveType.FrontWheelDrive:
			Wheel_Colliders [0].GetGroundHit (out wheelHit);
			AdjustTorque (wheelHit.forwardSlip);

			Wheel_Colliders [1].GetGroundHit (out wheelHit);
			AdjustTorque (wheelHit.forwardSlip);
			break;
		}
	}


	private void AdjustTorque (float forwardSlip)
	{
		if (forwardSlip >= m_SlipLimit && m_CurrentTorque >= 0) {
			m_CurrentTorque -= 10 ;
		} else {
			m_CurrentTorque += 10 ;
			if (m_CurrentTorque > EngineTorque) {
				m_CurrentTorque = EngineTorque;
			}
		}
	}
}

