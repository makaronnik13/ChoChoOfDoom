using UnityEngine;
using System.Collections;

public class RoadEditorTools : MonoBehaviour {

	private bool inCPMode;
	private Vector2 startCPPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Invoke ("CopyPasteMode", 0.5f);
		}

		if (Input.GetMouseButtonUp(0)) {
			CopyPasteMode();
		}

		if (inCPMode) {
			
		}
	}

	void CopyPasteMode(){
		if (!inCPMode) {
			startCPPosition = Input.mousePosition;
		}
		inCPMode = !inCPMode;
	}
}
