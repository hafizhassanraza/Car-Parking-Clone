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

// This script used for car front and back trigger when parking

using UnityEngine;
using System.Collections;

//Public enum for select trigger type in Inspector
public enum TriggerType{Front,Back}

public class TriggerFrontBack : MonoBehaviour
{


	// ParkingManager handler
	public ParkingManager manager;

	// Is front trigger or back?
	public TriggerType triggerType;

	// On parking triggers enter
	void OnTriggerEnter (Collider col)
	{
		
		// Is front trigger
		if (triggerType == TriggerType.Front) {
			if (col.tag == "Front") {
				manager.tFront = true;
			}
		} else {// Or back trigger?
			if (col.tag == "Back") {
				manager.tBack = true;
			}

		}
		
		
	}
	// On parking triggers exit
	void OnTriggerExit (Collider col)
	{
		
		if (triggerType == TriggerType.Front) {
			if (col.tag == "Front") {
				manager.tFront = false;
			}
		
		} else {
			if (col.tag == "Back") {
				manager.tBack = false;
			}

		}
	}
}
