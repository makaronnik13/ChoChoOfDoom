using UnityEngine;
using System.Collections;
using SimpleJSON;

public class ItemBase : MonoBehaviour {

	private JSONNode N;
	private Sprite[] itemsList;
	public TextAsset itemsTextAsset;

	// Use this for initialization
	void Start () {
		itemsList = Resources.LoadAll<Sprite>("sprites/items");
		//Debug.Log (itemsList[0]);
		N = JSON.Parse(itemsTextAsset.text)[0];
	}
	
	public Item GetItemById(int id){
		foreach (JSONNode node in N.AsArray) {
			if (node ["id"].AsInt == id) {
				return new Item (node ["id"].AsInt, node ["text"].Value, itemsList [node ["id"].AsInt], node ["type"].AsInt);
			}
		}
		return null;
	}


}
