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

// This script used for camera to follow smoothly player car

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SmoothFollow : MonoBehaviour
{

	
	public Transform target;
	// The distance in the x-z plane to the target
	public float distance = 10.0f;
	// the height we want the camera to be above the target
	public float height = 5.0f;
	// How much we
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;
     
	public Vector3 offset = Vector3.zero;

	// Rigidbody for smooth rotation   
	Rigidbody CarRigidBody;
     


	IEnumerator Start()
	{


		if (PlayerPrefs.GetInt ("Resolution") == 506 || PlayerPrefs.GetInt ("Resolution") == 720 || PlayerPrefs.GetInt ("Resolution") == 1080) {
			if (PlayerPrefs.GetInt ("Resolution") == 506)
				Screen.SetResolution (900, 506, true);
			if (PlayerPrefs.GetInt ("Resolution") == 720)
				Screen.SetResolution (1280, 720, true);
			if (PlayerPrefs.GetInt ("Resolution") == 1080)
				Screen.SetResolution (1920, 1080, true);

			GetComponent<Camera> ().aspect = 16f / 9f;
		}
		if(PlayerPrefs.GetInt("Loaded")!=3)
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			PlayerPrefs.SetInt("Loaded",3);
		}
		else
			PlayerPrefs.SetInt("Loaded",7);

	
	
		yield return new WaitForEndOfFrame ();
		// Find player car by tag after game started
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		CarRigidBody = target.GetComponent<Rigidbody> ();
	}
	void Update ()
	{
		// Early out if we don't have a target
		if (!target)
			return;
         
		if (!CarRigidBody)
			return;


//		Vector3 localVilocity = target.InverseTransformDirection (target.GetComponent<Rigidbody> ().velocity);

		// Calculate the current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;    
		Vector3 pos = target.position + Quaternion.AngleAxis (wantedRotationAngle, Vector3.up) * offset;
		float wantedHeight = height + pos.y;
     
             
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;
         
		// Smooth rotation by rigidboy  
		rotationDamping = Mathf.Lerp (0f, 3f, (CarRigidBody.velocity.magnitude * 3f) / 40f);

		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
     
		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);



		// Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
		;
	        
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = pos;

		transform.position -= currentRotation * Vector3.forward * distance;

		// Set the height of the camera
		transform.position = new Vector3 (transform.position.x, currentHeight, transform.position.z);
         
		// Always look at the target
		transform.LookAt (pos);
	}
}
      
