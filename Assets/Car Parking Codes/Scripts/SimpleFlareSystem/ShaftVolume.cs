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

public class ShaftVolume : MonoBehaviour
{

	// Target is main camera
	Transform target;

	// Shaft material instance
	Material mat;

	// Default color
	Color mainColor;

	// Alpha multiplier
	public float multiplier = 100f;

	// Max distance to start fade in\out
	public float MaxDistance;

	void Start ()
	{
			target = Camera.main.transform;
			mat = GetComponent<MeshRenderer> ().material;

		// Store material starting color
		mainColor = mat.GetColor ("_TintColor");
	}
	

	float distance;
	Vector3 eulerAngleOffset;

	void Update ()
	{
		if (!target || !mat)
			return;


		if (canCompute) {

			distance = Vector3.Distance (transform.position, target.position);

			mat.SetColor ("_TintColor", new Color (mainColor.r, mainColor.g, mainColor.b, distance / multiplier));

		}
	}


	public bool canCompute;

	void OnBecameVisible ()
	{
		canCompute = true;
	}

	void OnBecameInvisible ()
	{
		canCompute = false;
	}
}
