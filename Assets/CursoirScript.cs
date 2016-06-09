using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CursoirScript : MonoBehaviour {

	public Vector3 move;
	public int BlockType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Input.mousePosition + move;
		if (Input.GetMouseButtonDown (0)) {
			Invoke ("Select", 0.7f);
		}

		if (Input.GetMouseButtonDown (0)) {
			CancelInvoke ("Select");
		}
	}

	public void SetBlockType(int type, Sprite sprite){
		BlockType = type;

		if(type<0){
			GetComponentInChildren<Image> ().enabled = false;
		}
		else{
			GetComponentInChildren<Image> ().enabled = true;
			GetComponentInChildren<Image> ().sprite = sprite;
		}
	}

	void Select(){
		
	}

}
