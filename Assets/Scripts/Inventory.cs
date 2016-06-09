using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEditor;

public class Inventory : MonoBehaviour {
	//private List<string> goodies;

	public List<Item> items; 
	public ItemBase itemBase;

	void Start () {
		//hide item info after tap
		items = new List<Item> ();
		AddItem (138);AddItem (138);AddItem (138);AddItem (138);
	}

	bool AddItem(int itemNum){
		Item item = itemBase.GetItemById (itemNum);
		foreach(Item _item in items){
			if (item.ID == _item.ID) {
				_item.num++;
				return true;
			}
		}
		items.Add (item);
		return false;
	}

	public int ItemNum(int id){
		foreach(Item item in items){
			if (item.ID == id)
				return item.num;
		}
		return 0;
	}

	/*
	// Update is called once per frame
	void Update () {
	
	}

	public bool IfInGoodies(string[] goods){
		bool ret = true;
		foreach (string good in goods) {
				ret = ret && goodies.Contains (good);	
		}
		return ret;
	}

	public bool IfInGoodies(string good){
		if (goodies.Contains (good)) {
			return true;
		}
		return false;
	}

	public void RemoveGoodies(string[] goods){
		foreach (string good in goods) {
			goodies.Remove (good);
		}
	}

	public void RemoveGoodies(string good){
			goodies.Remove (good);
	}

	public void AddGoodies(string good){
			goodies.Add(good);
	}
	*/
}
