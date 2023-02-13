/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
public class ImageLoader : MonoBehaviour {

	// Use this for initialization
	public Image Plate;

	public string path  =  @"/mnt/sdcard/CarParking/Plate/";

	#if !UNITY_EDITOR
	IEnumerator Start () {
		if(!Directory.Exists(path))
			Directory.CreateDirectory(path);

	DirectoryInfo PlateInfo = new DirectoryInfo(path);
	WWW n = new WWW("file://"+PlateInfo.GetFiles()[0].FullName);
		yield return n;
	Plate.sprite = Sprite.Create(n.texture, new Rect(0, 0, n.texture.width, n.texture.height),new Vector2(0, 0),100.0f);
	}
	#endif
}
