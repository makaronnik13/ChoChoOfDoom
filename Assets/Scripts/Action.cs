using UnityEngine;
using System.Collections;

public class Action {

	public int Id;
	public int locationId;
	public Requarement[] requarements;
	public string text;
	public bool type;
	// Utese this for initialization

	public Action(int _ID, string _text, bool _type, int _locationId, Requarement[] _requarements){
		Id = _ID;
		text = _text;
		requarements = _requarements;
		type = _type;
		locationId = _locationId;
	}
}

public class Requarement{
	public int itemId;
	public string req;
	public int num;

	public Requarement(int _itemId, string _req, int _num){
		itemId = _itemId;
		req = _req;
		num = _num;
	}
}

