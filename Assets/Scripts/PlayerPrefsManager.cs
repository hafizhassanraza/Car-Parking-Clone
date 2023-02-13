using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {




   
	public static int CoinsPref
	{
		get{ return PlayerPrefs.GetInt ("Coins", 1500); }
		set{ PlayerPrefs.SetInt ("Coins", value); }
	}
	
    
}
