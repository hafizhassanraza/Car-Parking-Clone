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

public class CarRings : MonoBehaviour {

	public GameObject[] rings_0,rings_1,rings_2,rings_3;


	int carID;
	void Awake()
	{
		carID = PlayerPrefs.GetInt ("CarID");

		if (PlayerPrefs.GetInt (carID.ToString()+"RingID") == 0) {
			for (int a = 0; a <  rings_0.Length; a++) {
				 rings_0 [a].SetActive (true);
				 rings_1 [a].SetActive (false);
				 rings_2 [a].SetActive (false);
				 rings_3 [a].SetActive (false);
			}
		}
		if (PlayerPrefs.GetInt (carID.ToString()+"RingID") == 1) {
			for (int a = 0; a <  rings_1.Length; a++) {
				 rings_1 [a].SetActive (true);
				 rings_0 [a].SetActive (false);
				 rings_2 [a].SetActive (false);
				 rings_3 [a].SetActive (false);
			}
		}
		if (PlayerPrefs.GetInt (carID.ToString()+"RingID") == 2) {
			for (int a = 0; a <  rings_2.Length; a++) {
				 rings_2 [a].SetActive (true);
				 rings_1 [a].SetActive (false);
				 rings_0 [a].SetActive (false);
				 rings_3 [a].SetActive (false);
			}
		}
		if (PlayerPrefs.GetInt (carID.ToString()+"RingID") == 3) {
			for (int a = 0; a <  rings_3.Length; a++) {
				 rings_3 [a].SetActive (true);
				 rings_1 [a].SetActive (false);
				 rings_2 [a].SetActive (false);
				 rings_0 [a].SetActive (false);
			}
		}
	}
}
