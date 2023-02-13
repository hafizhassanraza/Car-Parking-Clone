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

// This script used for detect player collided with parked cars and activate alarm sound in parked car

using UnityEngine;
using System.Collections;

public class CollisionItemCar : MonoBehaviour
{
	//Accessing to TriggerManager.cs
	[HideInInspector]public ParkingManager triggerManager;

	//This is for internal usage
	bool CanCollid;

	//Car alarm lights;
	public Light[] AlarmLights;

	// Wait beform each alarm
	public float AlarmDelay  = 1f ;


	void Start ()
	{
		//Find TriggerManager by tag
		triggerManager = GameObject.FindGameObjectWithTag ("Manager").GetComponent<ParkingManager> ();

	}
	//When car is colide with parking items
	void OnCollisionEnter (Collision col)
	{
		if (!CanCollid) {
			if (col.gameObject.tag == "Player") {
				
				//Increase TriggerManager Collision Counts
				triggerManager.CollisionCount++;

				//Play collision Alarm sound
				triggerManager.AlarmSound.Play();

				// Start car alarming
				StartCoroutine (CarAlarm ());

				// Play car alarm sound
				GetComponent<AudioSource> ().Play ();
				Invoke("StopSiren", 10f);
				//Internal usage--------------------
				CanCollid = true;
				StartCoroutine (CanCollids ());
				//---------------------

				//Update collision count text
				triggerManager.CollistionCountText.text = triggerManager.CollisionCount.ToString ();

				//If collision counts is more than 3,Stop game and show Failed menu Object
				if (triggerManager.CollisionCount > 3) {
					GameManager.Instance.LevelFailPane.SetActive(true);


					//Destroy TriggerManager
					Destroy (triggerManager);
				}
			}
		}
	}

	//Internal Usage....
	IEnumerator CanCollids ()
	{


		yield return new WaitForSeconds (3f);
		CanCollid = false;
	}



		public void StopSiren() { 
		GetComponent<AudioSource>().Stop();
	}
	// Car alarm system
	IEnumerator CarAlarm()
	{

		while (true) {
			
			for (int a = 0; a < AlarmLights.Length; a++)
				AlarmLights [a].enabled = !AlarmLights [a].enabled;

			yield return new WaitForSeconds (AlarmDelay);
		}


	}
}
