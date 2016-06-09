using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class LocationRedactorPanel : MonoBehaviour , IPointerClickHandler{
	private DialogCreation dialogScript;
	public int type;
	// Use this for initialization
	void Start () {
		dialogScript = GameObject.Find ("EditorCanvas").GetComponent<DialogCreation> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerClick(PointerEventData eventData) // 3
	{
		dialogScript.ReInitMenu (type);
	}
}
