using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoadButton : MonoBehaviour {

	public int value;
	public Sprite[] roadSprites;

	void Start(){
	}

	public void Pressed(){
		value++;

		if (GameObject.Find ("cursoirController").GetComponent<CursoirScript> ().BlockType >= 0) {
			value = GameObject.Find ("cursoirController").GetComponent<CursoirScript> ().BlockType;
		}

		if (value > roadSprites.Length-1) {
			value = 0;
		}
		GetComponent<Image> ().sprite = roadSprites [value];
	}

	public void Init(int _value){
		value = _value;
		GetComponent<Image> ().sprite = roadSprites [value];
	}
}
