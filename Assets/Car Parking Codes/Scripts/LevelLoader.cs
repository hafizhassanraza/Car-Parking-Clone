
using UnityEngine;
using System.Collections;
public class LevelLoader : MonoBehaviour
{
	

	// Use this for initialization
	public GameObject[] Levels;




	void Awake ()
	{

			Levels [PlayerPrefs.GetInt ("CarLevelID")].SetActive (true);
	
	}
}
