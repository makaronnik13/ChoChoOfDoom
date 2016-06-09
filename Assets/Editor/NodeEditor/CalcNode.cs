using UnityEngine;
using System.Collections;
using UnityEditor;

public class CalcNode : BaseInputNode
{
	private BaseInputNode input1;
	private Rect input1Rect;
	private BaseInputNode input2;
	private Rect input2Rect;
	private int locationId;
	private int locationImage;
	private string locationText;

	public enum CalculationType {
		Addition,
		Subtraction,
		Multiplication,
		Division
	}

	public CalcNode()
	{
		windowTitle = "Location";
		hasInputs = true;
	}

	public override void DrawWindow()
	{
		base.DrawCurves();

		Event e = Event.current;


		GUILayout.Label("Input 1: ");

		if(e.type == EventType.Repaint)
		{
			input1Rect = GUILayoutUtility.GetLastRect();
		}

		GUILayout.Label("Input 2: ");
		
		if(e.type == EventType.Repaint)
		{
			input2Rect = GUILayoutUtility.GetLastRect();
		}

		GUILayout.Label("Text on location");
		locationText = EditorGUILayout.TextArea (locationText, GUILayout.Height (30));
		locationId  = EditorGUILayout.IntField ("Id: ", locationId);
		locationImage = EditorGUILayout.IntField ("Img: ", locationImage);
	}

	public override void SetInput(BaseInputNode input, Vector2 clickPos)
	{
		clickPos.x -= windowRect.x;
		clickPos.y -= windowRect.y;

		if(input1Rect.Contains(clickPos)) {
			input1 = input;
			
		} else if(input2Rect.Contains(clickPos)) {
			input2 = input;
		}
	}

	public override void DrawCurves()
	{
		if(input1)
		{
			Rect rect = windowRect;
			rect.x += input1Rect.x;
			rect.y += input1Rect.y + input2Rect.height/2;
			rect.width =1;
			rect.height =1;

			NodeEditor.DrawNodeCurve(input1.windowRect, rect);
		}

		if(input2) {
			Rect rect = windowRect;
			rect.x += input2Rect.x;
			rect.y += input2Rect.y + input2Rect.height / 2;
			rect.width = 1;
			rect.height = 1;
			
			NodeEditor.DrawNodeCurve(input2.windowRect, rect);
		}
	}
		
	public override BaseInputNode ClickedOnInput(Vector2 pos)
	{
		BaseInputNode retVal = null;

		pos.x -= windowRect.x;
		pos.y -= windowRect.y;

		if(input1Rect.Contains(pos))
		{
			retVal = input1;
			input1 = null;
		}
		else if(input2Rect.Contains(pos))
		{
			retVal = input2;
			input2 = null;
		}

		return retVal;
	}

	public override void NodeDeleted (BaseNode node)
	{
		if(node.Equals (input1)) {
			input1 = null;
		}
		
		if(node.Equals(input2)) {
			input2 = null;
		}
	}
}











