using UnityEngine;
using System.Collections;

public class Item {

	public int ID;
	public string text;
	public int num = 1;
	public Sprite img;
	public int type;

	// Utese this for initialization

	public Item(int _ID, string _text, Sprite _img, int _type){
		ID = _ID;
		text = _text;
		num = 1;
		img = _img;
		type = _type;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
