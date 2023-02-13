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

// This script is CarSelect.cs Editor\Inspector layout


using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor (typeof(CarSelect))][CanEditMultipleObjects]
public class CarSelectEditor : Editor
{
	public override void OnInspectorGUI ()
	{

		serializedObject.Update ();

		EditorGUILayout.Space ();

		GUI.color = Color.green;
		EditorGUILayout.Space ();
		EditorGUILayout.HelpBox ("\n                           Car Select System\n", MessageType.None);
		EditorGUILayout.Space ();
		GUI.color = Color.white;






		EditorGUILayout.HelpBox ("List of the cars", MessageType.None);

		EditorGUILayout.PropertyField (serializedObject.FindProperty ("vType"),
			new GUIContent ("Vehicle Type", "Select vehicle type"), true);
		EditorGUILayout.Space ();
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("cars"),
			new GUIContent ("Cars", "Drag youre car prefabs"), true);

		EditorGUILayout.Space ();

		EditorGUILayout.HelpBox ("Car spawn point", MessageType.None);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("point"),
			new GUIContent ("Spawn Point", "Drag spawn point transform"), true);
		EditorGUILayout.Space ();



		EditorGUILayout.HelpBox ("List of the car prices", MessageType.None);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("Values"),
			new GUIContent ("Car Price List", "Enter list of the car prices"), true);
		EditorGUILayout.Space ();



		EditorGUILayout.HelpBox ("Icon - Button - Shop", MessageType.None);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("Lock"),
			new GUIContent ("Lock Icon", "Drag lock icon image   "), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("Shop"),
			new GUIContent ("Shop Window", "Drag Shop Window image   "), true);

		EditorGUILayout.PropertyField (serializedObject.FindProperty ("Buy"),
			new GUIContent ("Buy Button", "Buy Button Object   "), true);
		EditorGUILayout.Space ();



		EditorGUILayout.HelpBox ("Info Texts", MessageType.None);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("TotalScore"),
			new GUIContent ("Total Score Text", "Drag Total Score Text   "), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("CarValue"),
			new GUIContent ("Car Price Text", "Drag Car Price Text   "), true);
		EditorGUILayout.Space ();



		EditorGUILayout.HelpBox ("Main Level Name", MessageType.None);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("LevelNameDay"),
			new GUIContent ("Level Name Day", "Enter Main Scene Day Mode Name  "), true);
		EditorGUILayout.Space ();
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("LevelNameNight"),
			new GUIContent ("Level Name Night", "Enter Main Scene Night Mode Name  "), true);
		EditorGUILayout.Space ();



		EditorGUILayout.HelpBox ("Loading Window", MessageType.None);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("Loading"),
			new GUIContent ("Loading Object", "Drag Loading GameObject  "), true);
		EditorGUILayout.Space ();

		EditorGUILayout.HelpBox ("Ring Sport", MessageType.None);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("ringSport"),
			new GUIContent ("Ring Sport Component", "Drag RingSport Component  "), true);
		EditorGUILayout.Space ();








		serializedObject.ApplyModifiedProperties ();
	}

}
