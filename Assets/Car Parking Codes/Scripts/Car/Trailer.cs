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

public class Trailer : MonoBehaviour {

	public WheelCollider[] Wheel_Colliders;
	public Transform[] Wheel_Transforms;

	Rigidbody rigid;

	public Vector3 centerOfMass;

	void Start()
	{
		Wheel_Colliders [0].attachedRigidbody.centerOfMass = centerOfMass;

		rigid = GetComponent<Rigidbody> ();
		rigid.interpolation = RigidbodyInterpolation.Interpolate;
	}
	void Update () 
	{
		for (int i = 0; i < Wheel_Colliders.Length; i++) 
		{
			Quaternion quat;
			Vector3 position;
			Wheel_Colliders [i].GetWorldPose (out position, out quat);
			Wheel_Transforms [i].transform.position = position;
			Wheel_Transforms [i].transform.rotation = quat;

		}


		for (int b = 0; b < Wheel_Colliders.Length; b++) {

			if(Wheel_Colliders[b].isGrounded)
				Wheel_Colliders [b].motorTorque = 0.3f;
			else
				Wheel_Colliders [b].motorTorque = 0;
		}

	}
}
