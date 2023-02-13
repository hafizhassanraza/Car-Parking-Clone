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
using UnityEngine.UI;
public class TimeDown : MonoBehaviour {
	// Use this for initialization




	public Text _text;

	public float seconds = 59; // Amount of seconds 
	public float minutes = 0; //Amount of minutes Text _text;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (seconds <= 0) {
			seconds = 59;

			if (minutes >= 1) {
				minutes --;
			} else {
				minutes = 0;
				seconds = 0;
				_text.text  = minutes.ToString ("f0") + ":0" + seconds.ToString ("f0");
			}
		} else 
		{
			seconds -= Time.deltaTime;
			_text.text = +minutes + ":"+ Mathf.FloorToInt(seconds);
		}


		if (minutes <= 0 && seconds <= 0)
			GetComponent<ParkingManager> ().TimeFailed ();	

	}
}
