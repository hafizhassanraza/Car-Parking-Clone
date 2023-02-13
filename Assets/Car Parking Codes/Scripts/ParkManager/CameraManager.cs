

using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	// Array Of the total cameras
	public Camera[] Cams;

	IEnumerator Start () {

		yield return new WaitForSeconds(0.01f);
        // Find  MainCamera (with SmoothFollow script) as first camera 
        if (GameObject.FindGameObjectWithTag("MainCamera"))
            Cams[0] = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //else
        //    Debug.Log("Please drag ManCamera prefab to scene");

        // Let's wait until the ca instantiate and find camera's from car childes

        if (GameObject.FindGameObjectWithTag("Camera1"))
            Cams[1] = GameObject.FindGameObjectWithTag("Camera1").GetComponent<Camera>();
        //else
        //    Debug.Log("Please add dashboard camera to car");

        if (GameObject.FindGameObjectWithTag("Camera2"))
            Cams[2] = GameObject.FindGameObjectWithTag("Camera2").GetComponent<Camera>();
        //else
        //    Debug.Log("Please add top view camera to car");

        //if(GameObject.FindGameObjectWithTag ("Camera3"))
        //	Cams[3]  =  GameObject.FindGameObjectWithTag ("Camera3").GetComponent<Camera>();
        //else
        //	Debug.Log ("Please add front view camera to car");

        //if(GameObject.FindGameObjectWithTag ("Camera4"))
        //	Cams[4]  =  GameObject.FindGameObjectWithTag ("Camera4").GetComponent<Camera>();
        //else
        //	Debug.Log ("Please add orbit view camera to car");

        // Diactivate all cameras and activate first camera
        for (int a = 0; a<Cams.Length; a++) 
		{
			Cams[a].gameObject.SetActive(false);
			Cams[CameraID].gameObject.SetActive(true);
		}
	}
	

	// current camera id
	int CameraID;


	//public function for changing camera button that called    from UI OnClick() Button
	public void NextCam()
	{

		if (CameraID < Cams.Length - 1)
			CameraID++;
		else
			CameraID = 0;

		for (int a = 0; a<Cams.Length; a++) 
			{
			Cams[a].gameObject.SetActive(false);
			Cams[CameraID].gameObject.SetActive(true);
		}
	}
}
