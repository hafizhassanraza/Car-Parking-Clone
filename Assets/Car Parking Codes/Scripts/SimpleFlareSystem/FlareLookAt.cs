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

// This script used for face the flare to camera
using UnityEngine;
using System.Collections;    

public class FlareLookAt : MonoBehaviour
{

	// Use this for initialization

	bool canCompute;

	void OnBecameVisible ()
	{
		canCompute = true;
	}

	Transform cam;

	public float updateInterval = 0.3f;

	public bool Raycast = true;


	void Start ()
	{
		cam = Camera.main.transform;

		if(Raycast)
			StartCoroutine (RayCast ());
		
		renderM = GetComponent<MeshRenderer> ();



	}

	void Update ()
	{
		if (canCompute) {
			transform.LookAt (cam.position);
		}
	}

	void OnBecameInVisible ()
	{
		canCompute = false;
	}


	MeshRenderer renderM;
	IEnumerator RayCast()
	{
		while (true) {
			yield return new WaitForSeconds (updateInterval);


			if (Physics.Linecast (transform.position, cam.transform.position))
				renderM.enabled = false;
			else
				renderM.enabled = true;




		}
	}
}
