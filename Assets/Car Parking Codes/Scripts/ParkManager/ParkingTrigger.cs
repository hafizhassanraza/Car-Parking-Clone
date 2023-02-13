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

// This script used for use in parking triggers

using UnityEngine;
using System.Collections;

public class ParkingTrigger : MonoBehaviour
{

	// Trigger number
	public int tNum;

	// ParkingManager handler
	public ParkingManager tManager;


	void OnTriggerStay (Collider col)
	{
		
		
		if (col.tag == "Player"||col.tag == "Trailer") {

			if (tNum == 1) 
				tManager.t0 = true;
			else if (tNum == 2)
				tManager.t1 = true;
			else if (tNum == 3)
				tManager.t2 = true;
			else if (tNum == 4)
				tManager.t3 = true;


		}   
		
		
		
		
	}

	void OnTriggerExit (Collider col)
	{
		
		
		if (col.tag == "Player"||col.tag == "Trailer") {
			if (tNum == 1)
				tManager.t0 = false;
			else if (tNum == 2)
				tManager.t1 = false;
			else if (tNum == 3)
				tManager.t2 = false;
			else if (tNum == 4)
				tManager.t3 = false;
			
			
			
		}
	}
}
