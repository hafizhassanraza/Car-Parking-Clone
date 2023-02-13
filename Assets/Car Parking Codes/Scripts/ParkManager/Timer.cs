/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/


// This is timer script for time limited parking
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Text timerLabel;
	float timecount;
	private float time,starttime;
	int fraction,minutes,seconds;


	void Start(){
		starttime = Time.time;
	}
	
	void Update() {

		timecount = Time.time - starttime;
		minutes = (int)Mathf.Floor(timecount / 60); //Divide the guiTime by sixty to get the minutes.
		seconds = (int)Mathf.Floor(timecount % 60);//Use the euclidean division for the seconds.
		fraction = (int)Mathf.Floor((timecount * 100) % 100);
		
		//update the label value
		timerLabel.text = string.Format ("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);
	}
}
