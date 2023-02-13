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

// This script used for Water texture scrolling offset

using UnityEngine;
using System.Collections;

public class WaterScroll : MonoBehaviour
{

	public float scrollSpeed1 = -0.07f, scrollSpeed2 = -0.07f;
	private Renderer rend;
	public string name1 = "_MainTex", name2 = "_SpecTex";

	void Start ()
	{
		if (!rend)
			rend = GetComponent<Renderer> ();
	}

	void Update ()
	{
		float offset1 = Time.time * scrollSpeed1;
		float offset2 = Time.time * scrollSpeed2;

		rend.material.SetTextureOffset (name1, new Vector2 (offset1, 0));
		rend.material.SetTextureOffset (name2, new Vector2 (offset2, 0));

	}
}
