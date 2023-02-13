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

public class RingSport : MonoBehaviour {


	public CarRings carRings;

	[HideInInspector]public int id;

	public int[] ringPrice;

	public Text ScoreText;

	public GameObject[] ringLocks;

	public GameObject Shop;

	[HideInInspector]public int carID;


	IEnumerator Start () 
	{
		
		PlayerPrefs.SetInt ("0Ring0", 3);
		PlayerPrefs.SetInt ("1Ring0", 3);
		carID = PlayerPrefs.GetInt ("CarID");

		CheakLocks ();

		yield return new WaitForEndOfFrame ();

		carRings = GameObject.FindGameObjectWithTag ("Player").GetComponent<CarRings> ();

		LoadRings ();    
	}
	

	public void SelectRing(int id)
	{

		if (PlayerPrefs.GetInt (carID.ToString()+"Ring" + id.ToString ()) != 3) {  // 3=>true - 0=>false
			
			if (PlayerPrefs.GetInt ("Coins") >= ringPrice [id]) 
			{

				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - ringPrice [id]);

				ScoreText.text = PlayerPrefs.GetInt ("Coins").ToString ();

				ringLocks [id].SetActive (false);

				PlayerPrefs.SetInt (carID.ToString()+"Ring"+id.ToString(), 3);

				PlayerPrefs.SetInt (carID.ToString()+"RingID", id);

				LoadRings ();
			}

			else
				Shop.SetActive (true);
			
		} 
		else 
		{
			
			PlayerPrefs.SetInt (carID.ToString()+"RingID", id);

			LoadRings ();

		}
	}
	public  void CheakLocks()
	{

		for(int a = 0;a<ringLocks.Length;a++)
		{
			if (PlayerPrefs.GetInt (carID.ToString()+"Ring" + a.ToString ()) == 3)
				ringLocks [a].SetActive (false);
			else
				ringLocks [a].SetActive (true);

		}
	}
	public void LoadRings()
	{
		


		CheakLocks ();

		if (PlayerPrefs.GetInt (carID.ToString()+"RingID") == 0) {
			for (int a = 0; a < carRings.rings_0.Length; a++) {
				carRings.rings_0 [a].SetActive (true);
				carRings.rings_1 [a].SetActive (false);
				carRings.rings_2 [a].SetActive (false);
				carRings.rings_3 [a].SetActive (false);
			}
		}
		if (PlayerPrefs.GetInt (carID.ToString()+"RingID") == 1) {
			for (int a = 0; a < carRings.rings_1.Length; a++) {
				carRings.rings_1 [a].SetActive (true);
				carRings.rings_0 [a].SetActive (false);
				carRings.rings_2 [a].SetActive (false);
				carRings.rings_3 [a].SetActive (false);
			}
		}
		if (PlayerPrefs.GetInt (carID.ToString()+"RingID") == 2) {
			for (int a = 0; a < carRings.rings_2.Length; a++) {
				carRings.rings_2 [a].SetActive (true);
				carRings.rings_1 [a].SetActive (false);
				carRings.rings_0 [a].SetActive (false);
				carRings.rings_3 [a].SetActive (false);
			}
		}
		if (PlayerPrefs.GetInt (carID.ToString()+"RingID") == 3) {
			for (int a = 0; a < carRings.rings_3.Length; a++) {
				carRings.rings_3 [a].SetActive (true);
				carRings.rings_1 [a].SetActive (false);
				carRings.rings_2 [a].SetActive (false);
				carRings.rings_0 [a].SetActive (false);
			}
		}

	}
}
