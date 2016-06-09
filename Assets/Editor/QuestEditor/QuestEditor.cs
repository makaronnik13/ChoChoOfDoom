using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class QuestEditor : EditorWindow
{
	List<Rect> locations;
	List<string> locationsText;
	List<int> locationsImages;
	List<int> locationsId;
	string fileName;
	private Vector2 mousePos;
	private Rect selectednode;
	private bool makeTransitionMode = false;

	[MenuItem ("Window/quest editor")]
	static void ShowEditor ()
	{
		QuestEditor editor = EditorWindow.GetWindow<QuestEditor> ();
		editor.Init ();
	}

	public void Init ()
	{
		locations = new List<Rect> ();
		locationsId = new List<int> ();
		locationsImages = new List<int> ();
		locationsText = new List<string> ();
	}

	void OnGUI ()
	{
		Event currentEvent = Event.current;
		mousePos = currentEvent.mousePosition;
		//DrawNodeCurve(locations[0], locations[1]); // Here the curve is drawn under the windows
		BeginWindows ();
		int i = 0;
		foreach (Rect location in locations) {
			locations [i] = GUI.Window (i, location, DrawNodeWindow, "Window" + i);
			i++;
		}
		EndWindows ();

		if (currentEvent.button == 1 && !makeTransitionMode) {
			if (currentEvent.type == EventType.MouseDown) {
				Debug.Log ("clicked");
				bool clickedOnWindow = false;
				int selectIndex = -1;
				for (i = 0; i < locations.Count; i++) {
					if (locations [i].Contains (mousePos)) {
						selectIndex = i;
						clickedOnWindow = true;
						break;
					}
				}

				if (!clickedOnWindow) {
					GenericMenu menu = new GenericMenu ();
					menu.AddItem (new GUIContent ("Add location"), false, CreateWindow, mousePos);
					menu.ShowAsContext ();
					currentEvent.Use ();
				} else {
					GenericMenu menu = new GenericMenu ();

					menu.AddItem (new GUIContent ("Make Transition"), false, ContextCallback, "makeTransition");
					menu.AddSeparator ("");
					menu.AddItem (new GUIContent ("Delete Node"), false, ContextCallback, "deleteNode");
					menu.ShowAsContext ();
					currentEvent.Use ();
				}

			}
		}
	}

	void ContextCallback (object obj)
	{
		string clb = obj.ToString ();


		if (clb.Equals ("makeTransition")) {
			bool clickedOnWindow = false;
			int selectIndex = -1;

			for (int i = 0; i < locations.Count; i++) {
				if (locations [i].Contains (mousePos)) {
					selectIndex = i;
					clickedOnWindow = true;
					break;
				}
			}

			if (clickedOnWindow) {
				selectednode = locations [selectIndex];
				makeTransitionMode = true;
			}
		} else if (clb.Equals ("deleteNode")) {
			bool clickedOnWindow = false;
			int selectIndex = -1;

			for (int i = 0; i < locations.Count; i++) {
				if (locations [i].Contains (mousePos)) {
					selectIndex = i;
					clickedOnWindow = true;
					break;
				}
			}

			if (clickedOnWindow) {
				Rect selNode = locations [selectIndex];
				locations.RemoveAt (selectIndex);

				//foreach(BaseNode n in locations)
				//{
				//	n.NodeDeleted(selNode);
				//}
			}
		}
	}

	void CheckCurve (object start)
	{
	}

	void CreateWindow (object pos)
	{
		Event currentEvent = Event.current;
		Rect rect = new Rect (((Vector2)pos).x, ((Vector2)pos).y, 200, 300);
		locations.Add (rect);
		locationsText.Add ("");
		locationsId.Add (0);
		locationsImages.Add (0);
	}

	void DrawNodeWindow (int id)
	{
		GUILayout.Label ("location text");
		locationsText [id] = EditorGUILayout.TextArea (locationsText [id], GUILayout.Height (30));
		locationsId [id] = EditorGUILayout.IntField ("Id: ", locationsId [id]);
		locationsImages [id] = EditorGUILayout.IntField ("Img: ", locationsImages [id]);
		GUI.DragWindow ();
	}

	void DrawNodeCurve (Rect start, Rect end)
	{
		Vector3 startPos = new Vector3 (start.x + start.width, start.y + start.height / 2, 0);
		Vector3 endPos = new Vector3 (end.x, end.y + end.height / 2, 0);
		Vector3 startTan = startPos + Vector3.right * 50;
		Vector3 endTan = endPos + Vector3.left * 50;
		Color shadowCol = new Color (0, 0, 0, 0.06f);
		for (int i = 0; i < 3; i++) // Draw a shadow
			Handles.DrawBezier (startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);
		Handles.DrawBezier (startPos, endPos, startTan, endTan, Color.black, null, 1);
	}
}