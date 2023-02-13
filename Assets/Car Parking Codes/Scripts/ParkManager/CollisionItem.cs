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

// This is collision detection script that increase CollisionCount in TriggerManager.cs 
//If collision count is more than 3,Finish Menu be activated from TriggerManager.cs

using UnityEngine;
using System.Collections;

public class CollisionItem : MonoBehaviour
{
	//Accessing to TriggerManager.cs
	[HideInInspector]public ParkingManager triggerManager;

	//This is for internal usage
	bool CanCollid;

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

				//Internal usage--------------------
				CanCollid = true;
				StartCoroutine (CanCollids ());
				//---------------------

				//Update collision count text
				triggerManager.CollistionCountText.text = triggerManager.CollisionCount.ToString ();

				//If collision counts is more than 3,Stop game and show Failed menu Object
				if (triggerManager.CollisionCount > 2) {
					GameManager.Instance.LevelFailPane.SetActive (true);
					triggerManager.Controller.SetActive (false);
					GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ().isKinematic = true;
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
}
