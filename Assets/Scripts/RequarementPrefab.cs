using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RequarementPrefab : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void SetRequarement(Requarement req){
		GetComponentInChildren<Text> ().text = req.req + req.num;
		GetComponentInChildren<Image> ().sprite = GameObject.FindGameObjectWithTag ("data").GetComponent<ItemBase>().GetItemById(req.itemId).img;
	}
}
