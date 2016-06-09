using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.Collections.Generic;

public class ActionsBase : MonoBehaviour {

	private JSONNode N;
	public TextAsset itemsTextAsset;

	// Use this for initialization
	void Start () {
		//Debug.Log (itemsList[0]);
		N = JSON.Parse(itemsTextAsset.text)[0];
		/*
		Debug.Log (GetActionById(0).Id);
		Debug.Log (GetActionById(0).locationId);
		Debug.Log (GetActionById(0).text);
		foreach (Requarement req in GetActionById(0).requarements) {
			Debug.Log (req.itemId);
			Debug.Log (req.num);
			Debug.Log (req.req);
		}
	*/

	}

	public Action GetActionById(int id){
		List<Requarement> reqs = new List<Requarement>();

		foreach (JSONNode node in N.AsArray) {
			if (node ["id"].AsInt == id) {
				foreach(JSONNode need in node ["needs"].AsArray){
					Requarement req = new Requarement(need["item"].AsInt, need["condition"].Value, need["number"].AsInt);
					reqs.Add (req);
				}
				return new Action (
					node  ["id"].AsInt, 
					node  ["text"].Value,
					node  ["type"].AsBool,
					node  ["locationId"].AsInt, 
					reqs.ToArray());
			}
		}
		return null;
	}
}

