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

// This script used for car selection system in game menu(garage)

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum VehicleType
{
	Car,
	//Bus,
	//Truck
}
public class CarSelect : MonoBehaviour
{


	// Car prefabs array
	public GameObject[] cars;

	// SpawnPoint
	public Transform point;

	// Ech car value
	public int[] Values;

	// Lock Icon,Shop window,Buy button
	public GameObject Lock, Shop, Buy;

	// Selected car ID
	int ID;

	//TotalScore text, Car value text
	public Text TotalScore, CarValue;
	
	// SetActive(true) loading window before start loading level
	public GameObject Loading;

	// MainLevel name
	public string LevelNameDay = "MainLevel",LevelNameNight = "MainLevel";

	public VehicleType vType;

	public RingSport ringSport;

	void Start ()
	{

		if (PlayerPrefs.GetInt ("FirstRun") != 3) {
			// If game s first run, make car0 buyed(opened)
			PlayerPrefs.SetInt ("Car0", 3);
		//	PlayerPrefs.SetInt ("Bus0", 3);
		//	PlayerPrefs.SetInt ("Truck0", 3);
			PlayerPrefs.SetInt ("FirstRun", 3);
		}
		
		// Read lastest car selected ID before    
		if(vType == VehicleType.Car)
			ID = PlayerPrefs.GetInt ("CarID");
		//if(vType == VehicleType.Bus)
		//	ID = PlayerPrefs.GetInt ("BusID");
		//if(vType == VehicleType.Truck)
		//	ID = PlayerPrefs.GetInt ("TruckID");

		// Instantiate last selected car by saved ID
		Instantiate (cars [ID], point.position, point.rotation);

		// Update total score text
		TotalScore.text = PlayerPrefs.GetInt ("Coins").ToString ();

		// Update current car value text
		CarValue.text = Values [ID].ToString ();


		// Update current car is locked or not
		if (vType == VehicleType.Car) {
			if (PlayerPrefs.GetInt ("Car" + ID.ToString ()) == 3) {
				Lock.SetActive (false);
				Buy.SetActive (false);
			} else {
				Lock.SetActive (true);
				Buy.SetActive (true);
			}
		}
		//if (vType == VehicleType.Bus) {
		//	if (PlayerPrefs.GetInt ("Bus" + ID.ToString ()) == 3) {
		//		Lock.SetActive (false);
		//		Buy.SetActive (false);
		//	} else {
		//		Lock.SetActive (true);
		//		Buy.SetActive (true);
		//	}
		//}
		//if (vType == VehicleType.Truck) {
		//	if (PlayerPrefs.GetInt ("Truck" + ID.ToString ()) == 3) {
		//		Lock.SetActive (false);
		//		Buy.SetActive (false);
		//	} else {
		//		Lock.SetActive (true);
		//		Buy.SetActive (true);
		//	}
		//}
	}

	GameObject tempG;

	// Public function for NextCar select button in menu
	public void NextCar ()
	{
		if (ID < cars.Length - 1)
			ID++;
    
		if (vType == VehicleType.Car)
			PlayerPrefs.SetInt ("CarID", ID);
		//if (vType == VehicleType.Bus)
		//	PlayerPrefs.SetInt ("BusID", ID);
		//if (vType == VehicleType.Truck)
		//	PlayerPrefs.SetInt ("TruckID", ID);


		Destroy (GameObject.FindGameObjectWithTag ("Player"));
		tempG = (GameObject)Instantiate (cars [ID], point.position, point.rotation);

		if (vType == VehicleType.Car) {
			if (ringSport) {
				ringSport.carID = ID;
				ringSport.carRings = tempG.GetComponent<CarRings> ();
				ringSport.LoadRings ();
				ringSport.CheakLocks ();
			}
		}

		if (vType == VehicleType.Car) {
			if (PlayerPrefs.GetInt ("Car" + ID.ToString ()) == 3) {
				Lock.SetActive (false);
				Buy.SetActive (false);
			} else {
				Lock.SetActive (true);
				Buy.SetActive (true);
			}
		}
		//if (vType == VehicleType.Bus) {
		//	if (PlayerPrefs.GetInt ("Bus" + ID.ToString ()) == 3) {
		//		Lock.SetActive (false);
		//		Buy.SetActive (false);
		//	} else {
		//		Lock.SetActive (true);
		//		Buy.SetActive (true);
		//	}
		//}
		//if (vType == VehicleType.Truck) {
		//	if (PlayerPrefs.GetInt ("Truck" + ID.ToString ()) == 3) {
		//		Lock.SetActive (false);
		//		Buy.SetActive (false);
		//	} else {
		//		Lock.SetActive (true);
		//		Buy.SetActive (true);
		//	}
		//}


		CarValue.text = Values [ID].ToString ();

	}
	// Public function for PrevCar select button in menu
	public void PrevCar ()
	{

		if (ID > 0)
			ID--;

		if (vType == VehicleType.Car)
			PlayerPrefs.SetInt ("CarID", ID);
		//if (vType == VehicleType.Bus)
		//	PlayerPrefs.SetInt ("BusID", ID);
		//if (vType == VehicleType.Truck)
		//	PlayerPrefs.SetInt ("TruckID", ID);


		Destroy (GameObject.FindGameObjectWithTag ("Player"));
		tempG = (GameObject)Instantiate (cars [ID], point.position, point.rotation);
		if (vType == VehicleType.Car) {
			if (ringSport) {
				ringSport.carID = ID;
				ringSport.carRings = tempG.GetComponent<CarRings> ();
				ringSport.LoadRings ();
				ringSport.CheakLocks ();
			}
		}

		if (vType == VehicleType.Car) {
			if (PlayerPrefs.GetInt ("Car" + ID.ToString ()) == 3) {
				Lock.SetActive (false);
				Buy.SetActive (false);
			} else {
				Lock.SetActive (true);
				Buy.SetActive (true);
			}
		}
		//if (vType == VehicleType.Bus) {
		//	if (PlayerPrefs.GetInt ("Bus" + ID.ToString ()) == 3) {
		//		Lock.SetActive (false);
		//		Buy.SetActive (false);
		//	} else {
		//		Lock.SetActive (true);
		//		Buy.SetActive (true);
		//	}
		//}
		//if (vType == VehicleType.Truck) {
		//	if (PlayerPrefs.GetInt ("Truck" + ID.ToString ()) == 3) {
		//		Lock.SetActive (false);
		//		Buy.SetActive (false);
		//	} else {
		//		Lock.SetActive (true);
		//		Buy.SetActive (true);
		//	}
		//}

		CarValue.text = Values [ID].ToString ();

	}
	// Select current car
	public void SelectCar ()
	{
		// If selected car is open,then Start game
		if (vType == VehicleType.Car) {
			if (PlayerPrefs.GetInt ("Car" + ID.ToString ()) == 3) {

				// Set current selected car ID for instantiate in main level    
				PlayerPrefs.SetInt ("CarID", ID);

				// Activate loading screen
				Loading.SetActive (true);

				if (PlayerPrefs.GetInt ("NightMode") == 3) { // 3=>true  , 0 =>false
					SceneManager.LoadScene (LevelNameNight);
				} else {
					SceneManager.LoadScene (LevelNameDay);
				}

			}
		}
		//if (vType == VehicleType.Bus) {
		//	if (PlayerPrefs.GetInt ("Bus" + ID.ToString ()) == 3) {

		//		// Set current selected car ID for instantiate in main level    
		//		PlayerPrefs.SetInt ("BusID", ID);

		//		// Activate loading screen
		//		Loading.SetActive (true);

		//		if (PlayerPrefs.GetInt ("NightMode") == 3) { // 3=>true  , 0 =>false
		//			SceneManager.LoadScene (LevelNameNight);
		//		} else {
		//			SceneManager.LoadScene (LevelNameDay);
		//		}

		//	}
		//}

		//if (vType == VehicleType.Truck) {
		//	if (PlayerPrefs.GetInt ("Truck" + ID.ToString ()) == 3) {

		//		// Set current selected car ID for instantiate in main level    
		//		PlayerPrefs.SetInt ("TruckID", ID);

		//		// Activate loading screen
		//		Loading.SetActive (true);

		//		if (PlayerPrefs.GetInt ("NightMode") == 3) { // 3=>true  , 0 =>false
		//			SceneManager.LoadScene (LevelNameNight);
		//		} else {
		//			SceneManager.LoadScene (LevelNameDay);
		//		}

		//	}
		//}
	}

	
	// Buy current selected car
	public void BuyCar ()
	{
		// If player have enough money, buy selected car
		if (vType == VehicleType.Car) {
			if (Values [ID] <= PlayerPrefs.GetInt ("Coins")) {

				PlayerPrefs.SetInt ("Car" + ID.ToString (), 3);

				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - Values [ID]);
				{
					Lock.SetActive (false);
					Buy.SetActive (false);
				}

				TotalScore.text = PlayerPrefs.GetInt ("Coins").ToString ();



			} else// If player did't have enough money, Show shop offer window   
			Shop.SetActive (true);
		}

		//if (vType == VehicleType.Bus) {
		//	if (Values [ID] <= PlayerPrefs.GetInt ("Coins")) {

		//		PlayerPrefs.SetInt ("Bus" + ID.ToString (), 3);

		//		PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - Values [ID]);
		//		{
		//			Lock.SetActive (false);
		//			Buy.SetActive (false);
		//		}

		//		TotalScore.text = PlayerPrefs.GetInt ("Coins").ToString ();



		//	} else// If player did't have enough money, Show shop offer window   
		//		Shop.SetActive (true);
		//}

		//if (vType == VehicleType.Truck) {
		//	if (Values [ID] <= PlayerPrefs.GetInt ("Coins")) {

		//		PlayerPrefs.SetInt ("Truck" + ID.ToString (), 3);

		//		PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - Values [ID]);
		//		{
		//			Lock.SetActive (false);
		//			Buy.SetActive (false);
		//		}

		//		TotalScore.text = PlayerPrefs.GetInt ("Coins").ToString ();



		//	} else// If player did't have enough money, Show shop offer window   
		//		Shop.SetActive (true);
		//}
	}
}
