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

// This script is ParkingManager.cs Editor\Inspector layout


using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(ParkingManager))][CanEditMultipleObjects]
public class ParkingManagerEditor : Editor
{
	
	Texture2D MainIcon;

	ParkingManager pm;

	void Awake ()
	{
		//MainIcon = Resources.Load ("CarController", typeof(Texture2D)) as Texture2D;
	}

	public override void OnInspectorGUI ()
	{
		pm = (ParkingManager)target;

		serializedObject.Update ();



		//EditorGUILayout.Space ();

		GUI.color = Color.green;
		//EditorGUILayout.Space ();
		//GUILayout.FlexibleSpace ();
		EditorGUILayout.HelpBox ("Car Parking Game", MessageType.None);
		//GUILayout.FlexibleSpace ();
		//EditorGUILayout.Space ();
		//GUI.color = Color.white;
		//GUILayout.BeginHorizontal ();
		//GUILayout.FlexibleSpace ();
		//GUILayout.Label (new GUIContent ("", MainIcon, ""), GUILayout.Height (140), GUILayout.Width (300));
		//GUILayout.FlexibleSpace ();
		//GUILayout.EndHorizontal ();


		//----------------------------------------------------------------------------------
		GUI.color = Color.green;
		EditorGUILayout.Space ();
		EditorGUILayout.HelpBox ("Parking Menus", MessageType.None);
		EditorGUILayout.Space ();
		GUI.color = Color.white;
		EditorGUILayout.Space ();
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("vType"),
			new GUIContent ("Vehicle Type", "Choose vehicle type "), true);

		EditorGUILayout.Space ();
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("timeLimit"),
		                               new GUIContent ("Time Limited ", "Is Time Limited ? "), true);

		if (pm.timeLimit) {
			EditorGUILayout.PropertyField (serializedObject.FindProperty ("TimeDownMenu"),
				new GUIContent ("Timer Menu", "Drag TimeDownMenu GameObject Here"), true);
			
			EditorGUILayout.PropertyField (serializedObject.FindProperty ("_text"),
				new GUIContent ("Timer Text", "Drag Timer Text Here"), true);
			
			EditorGUILayout.PropertyField (serializedObject.FindProperty ("minutes"),
				new GUIContent ("Minutes", "minutes"), true);
			
			EditorGUILayout.PropertyField (serializedObject.FindProperty ("seconds"),
				new GUIContent ("Seconds", " seconds"), true);




		}
		//EditorGUILayout.PropertyField (serializedObject.FindProperty ("FinishMenu"),
		//	new GUIContent ("Finish Menu", "Drag finish menu GameObject here"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("TimerCountMen"),
			new GUIContent ("TimerCount Menu", "Drag timerCount menu GameObject here"), true);

	//	EditorGUILayout.PropertyField (serializedObject.FindProperty ("FailedMenu"),
		//	new GUIContent ("FailedParking Menu", "Drag failed parking menu GameObject here"), true);
		//----------------------------------------------------------------------------------

		


		//----------------------------------------------------------------------------------
		GUI.color = Color.green;
		EditorGUILayout.Space ();
		EditorGUILayout.HelpBox ("Collision Count Scores", MessageType.None);
		EditorGUILayout.Space ();
		GUI.color = Color.white;


		EditorGUILayout.PropertyField (serializedObject.FindProperty ("CollisionScore0"),
			new GUIContent ("Collision Score 0", "Collision Score 0"), true);

		EditorGUILayout.PropertyField (serializedObject.FindProperty ("CollisionScore1"),
			new GUIContent ("Collision Score 1", "Collision Score 1"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("CollisionScore2"),
			new GUIContent ("Collision Score 2", "Collision Score 2"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("CollisionScore3"),
			new GUIContent ("Collision Score 3", "Collision Score 3"), true);
		//----------------------------------------------------------------------------------

		//----------------------------------------------------------------------------------
		GUI.color = Color.green;
		EditorGUILayout.Space ();
		EditorGUILayout.HelpBox ("Paring Info Texts", MessageType.None);
		EditorGUILayout.Space ();
		GUI.color = Color.white;


		EditorGUILayout.PropertyField (serializedObject.FindProperty ("CountDownText"),
			new GUIContent ("Count Down Text", "Drag count down info text "), true);

		EditorGUILayout.PropertyField (serializedObject.FindProperty ("CollistionCountText"),
			new GUIContent ("Collistion Count Text", "Drag collistion count info text"), true);

		EditorGUILayout.PropertyField (serializedObject.FindProperty ("FinishScoreText"),
			new GUIContent ("Finish Score Text", "Drag finish score info Text"), true);
		//----------------------------------------------------------------------------------


		//----------------------------------------------------------------------------------
		GUI.color = Color.green;
		EditorGUILayout.Space ();
		EditorGUILayout.HelpBox ("Utility", MessageType.None);
		EditorGUILayout.Space ();
		GUI.color = Color.white;


		EditorGUILayout.PropertyField (serializedObject.FindProperty ("ParkRenderer"),
			new GUIContent ("Park Place Renderer", "Drag park place renderer "), true);

		EditorGUILayout.PropertyField (serializedObject.FindProperty ("Controller"),
			new GUIContent ("Car Controller (Mobile)  ", "Drag mobile car controller to disable when parking  finished"), true);

		//----------------------------------------------------------------------------------


		EditorGUILayout.PropertyField (serializedObject.FindProperty ("AlarmSound"),
			new GUIContent ("AlarmSound", "Drag AlarmSound clip"), true);


		//----------------------------------------------------------------------------------
		GUI.color = Color.green;
		EditorGUILayout.Space ();
		EditorGUILayout.HelpBox ("Finish Effects", MessageType.None);
		EditorGUILayout.Space ();
		GUI.color = Color.white;

		EditorGUILayout.PropertyField (serializedObject.FindProperty ("star1"),
			new GUIContent ("1 Star", "Drag Star1 GameObject"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("star2"),
			new GUIContent ("2 Star", "Drag Star2 GameObject"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("star3"),
			new GUIContent ("3 Star", "Drag Star3 GameObject"), true);


		EditorGUILayout.Space ();EditorGUILayout.Space ();
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("bestTime"),
			new GUIContent ("BestTime Text", "Drag finish menu best time text here    "), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("currentTime"),
			new GUIContent ("CurrentTime Text", "Drag finish menu current time text here"), true);


		EditorGUILayout.Space ();EditorGUILayout.Space ();
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("clipSucces"),
			new GUIContent ("Winner Clip", "Drag Win Sound Clip Here"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("clipLost"),
			new GUIContent ("Lost Clip", "Drag Lost Sound Clip Here"), true);
		serializedObject.ApplyModifiedProperties ();
	}

}
