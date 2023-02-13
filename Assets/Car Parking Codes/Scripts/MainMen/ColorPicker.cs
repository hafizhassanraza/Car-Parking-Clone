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

// This script used for color picking system in game menu(garage)

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorPicker : MonoBehaviour {

	// List of the colors
	public Color[] Colors;

	public VehicleType vehicleType;

	// Public function for changing color buttons
	public void SetColor (int id)
	{
		if (vehicleType == VehicleType.Car) {
			PlayerPrefs.SetInt ("CarColor" + PlayerPrefs.GetInt ("CarID").ToString (), id);
		}
		//if (vehicleType == VehicleType.Bus) {
		//	PlayerPrefs.SetInt ("BusColor" + PlayerPrefs.GetInt ("BusID").ToString (), id);
		//}

		//if (vehicleType == VehicleType.Truck) {
		//	PlayerPrefs.SetInt ("TruckColor" + PlayerPrefs.GetInt ("TruckID").ToString (), id);
		//}
 			GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<ColorLoader>().mat.color = Colors [id];

	}
}
