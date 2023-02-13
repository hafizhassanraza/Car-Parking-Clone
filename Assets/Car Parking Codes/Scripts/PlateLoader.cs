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

// This script used for load car pelak from mobile sd card in this path:/mnt/sdcard/CarParking/Pelak/

using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
public class PlateLoader : MonoBehaviour {

	// Target renderer for assign pelak texture
	[Space(7)]
	public GameObject target1,target2;

	// Texture index on target directory => first texture or second or ...;
	[Space(7)]
	public int FileIndex;

	// Texture path on SD Card
	[Space(7)]
	public string path = @"/mnt/sdcard/CarParking/Plate/"
		;
	#if !UNITY_EDITOR
	IEnumerator Start()
	{
	DirectoryInfo df = new DirectoryInfo (path);
		if (df.GetFiles ().Length >= 0) {
			
	WWW www = new WWW ("file://" + df.GetFiles () [FileIndex].FullName);
			yield return www;
	target1.GetComponent<Renderer>().material.mainTexture = www.texture;
	target2.GetComponent<Renderer>().material.mainTexture = www.texture;
			www = null;
			www.Dispose ();
		}
	}
	#endif
}
