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

// This script used for load and instantiate car that selected in garage

using UnityEngine;
using System.Collections;


public class CarLoader : MonoBehaviour
{

	//List of the car prefabs
	public GameObject[] Car;

	void Awake ()
	{
		// Instantiate car by loaded  Car ID from  selected in car garage   
		Instantiate (Car [PlayerPrefs.GetInt ("CarID")], transform.position, transform.rotation);
	}
}
