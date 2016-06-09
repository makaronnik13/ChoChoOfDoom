using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.Collections.Generic;

public class LocationsBase : MonoBehaviour {

	private JSONNode N;
	private Sprite[] locationsList;
	public TextAsset itemsTextAsset;
	public ActionsBase actions;

	// Use this for initialization
	void Start () {
		locationsList = Resources.LoadAll<Sprite>("sprites/locations");
		//Debug.Log (itemsList[0]);
		N = JSON.Parse(itemsTextAsset.text)[0];

		/*
		Debug.Log (GetLocationById(0).Id);
		Debug.Log (GetLocationById(0).img);
		Debug.Log (GetLocationById(0).text);
		foreach (Action act in GetLocationById(0).actions) {
			Debug.Log (act.Id);
			Debug.Log (act.locationId);
			Debug.Log (act.requarements);
			Debug.Log (act.text);
		}
		*/

	}
	JSONArray a = new JSONArray();

	public Location GetLocationById(int id){
		List<Action> actionsList = new List<Action> ();

		foreach (JSONNode node in N.AsArray) {
			if (node ["id"].AsInt == id) {
				foreach (JSONNode i in  node["actions"].AsArray) {
					actionsList.Add (actions.GetActionById(i.AsInt));
				}
				return new Location (node ["id"].AsInt, node ["text"].Value, locationsList[node ["id"].AsInt], actionsList.ToArray());
			}
		}
		return null;
	}


}
