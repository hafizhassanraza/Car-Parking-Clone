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
//          Edited by AliyerEdon in summer 2016  -  Orginally from Unity Standard Assets car demo
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for car audio system

using System;
using UnityEngine;
using Random = UnityEngine.Random;


[RequireComponent (typeof(CarController))]
public class CarAudio : MonoBehaviour
{
	public AudioClip EngineSound;

	public AudioSource reverseAlarm;

	public float pitchMultiplier = 1f;

	public float PitchMin = 1f;

	public float PitchMax = 6f;

	[HideInInspector]public AudioSource audioSource;


	private CarController m_CarController;   

	public float crashVelocity = 10f;

	private void Start ()
	{
		m_CarController = GetComponent<CarController> ();

		gameObject.AddComponent<AudioSource> ();

		audioSource = GetComponent<AudioSource>();

		audioSource.clip = EngineSound;
		   
		audioSource.loop = true;

		audioSource.Play ();

		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name.Contains ("Garage"))
			isGarage = true;
		else
			isGarage = false;
		
	}

	private void Update ()
	{
			// The pitch is interpolated between the min and max values, according to the car's revs.
			float pitch = ULerp (PitchMin, PitchMax, m_CarController.Revs);

			// clamp to minimum pitch (note, not clamped to max for high revs while burning out)
			pitch = Mathf.Min (PitchMax, pitch);

			audioSource.pitch = pitch * pitchMultiplier;

			//audioSource.volume = 1f;
	}

	private static float ULerp (float from, float to, float value)
	{
		return (1.0f - value) * from + value * to;   
	}

	public AudioSource crashSound;

	bool isGarage;

	void OnCollisionEnter(Collision collision)
	{

		if (collision.relativeVelocity.magnitude > crashVelocity) {

			if (!crashSound.isPlaying) {
				if(!isGarage)
					crashSound.Play ();

			}

		}
	}
}

