using UnityEngine;
using System.Collections;

public class Location{
	public int Id;
	public Sprite img;
	public string text;
	public Action[] actions;
	// Utese this for initialization

	public Location(int _ID, string _text, Sprite _img, Action[] _actions){
		Id = _ID;
		text = _text;
		img = _img;
		actions = _actions;
	}
}


