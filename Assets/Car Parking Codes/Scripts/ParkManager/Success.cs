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

// This script used for success menu buttons

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Success : MonoBehaviour
{
	[Header("Success Menu Manager")]

	// Loading text for "Loading..."
	public Text LoadingTXT;

	// Parking Manager handler
	[HideInInspector]public ParkingManager manager;

	public string garageName = "MainMenu" ;

	public VehicleType vehicleType;


	// Activate parking place helper
	public void  ActiveHelper ()
	{
		manager.Helper.SetActive (!manager.Helper.activeSelf);
	}


	public IEnumerator Start ()
	{

		// Delay and find manager
		yield return new WaitForSeconds (.3f);
		manager = GameObject.FindGameObjectWithTag ("Manager").GetComponent<ParkingManager> ();
	}

	// SuccessMenu continue button
	public void Continue ()
	{
		//LoadingTXT.text = "Loading...";

		//if(vehicleType == VehicleType.Bus)
		//	PlayerPrefs.SetInt ("BusLevelID", PlayerPrefs.GetInt ("BusLevelID") + 1);
		//if(vehicleType == VehicleType.Truck)
		//	PlayerPrefs.SetInt ("TruckLevelID", PlayerPrefs.GetInt ("TruckLevelID") + 1);
		if (vehicleType == VehicleType.Car)
		{
			if (PlayerPrefs.GetInt("CarLevelID") < 39)
			{
				if (PlayerPrefs.GetInt("CarLevelID") == PlayerPrefs.GetInt("CarUnlockedLevel"))
				{
					print("unlock");
					PlayerPrefs.SetInt("CarUnlockedLevel", PlayerPrefs.GetInt("CarUnlockedLevel") + 1);

				}
					PlayerPrefs.SetInt("CarLevelID", PlayerPrefs.GetInt("CarLevelID") + 1);
			}
		}
		GameManager.Instance.SceneLoad("GamePlay");
		//SceneManager.LoadScene  (SceneManager.GetActiveScene().name);
	


	}


	// SuccessMenu retry button
	public void Retry ()
	{
		GameManager.Instance.SceneLoad("GamePlay");
	}


	//SuccessMenu exit button    
	public void Exit ()
	{
		GameManager.Instance.SceneLoad("MainMenu");
	}
}
