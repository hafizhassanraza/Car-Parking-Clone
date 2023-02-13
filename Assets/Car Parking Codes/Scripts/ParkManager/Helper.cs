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
using UnityEngine.SceneManagement;

public class Helper : MonoBehaviour
{

	// Target for helper arrow lookAt
	GameObject Target;

	// Distance to target need to hide helper   arrow
	public float DistanceToHide;

	// Is game started and parking place activated?
	bool Started;

	IEnumerator Start ()
	{



		if ( SceneManager.GetActiveScene().name == "Garage")
			Destroy (gameObject);

	
		yield return new WaitForSeconds (.02f);
		Started = true;
		Target = GameObject.FindGameObjectWithTag ("ParkPlace");
	}

	// Update is called once per frame
	void Update ()
	{
		if (Started) {
			Vector3 eulerAngles = transform.rotation.eulerAngles;
			eulerAngles.x = 0;
			eulerAngles.z = 0;
		
			transform.rotation = Quaternion.Euler (eulerAngles);
		
		
			if (Target) {
				if (Vector3.Distance (transform.position, Target.transform.position) <= DistanceToHide)
					GetComponentInChildren<MeshRenderer> ().enabled = false;
				else {



					transform.LookAt (Target.transform.position
					);


				}
			}

		}
	}
}
