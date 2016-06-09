using UnityEngine;
using System.Collections;

public class InventoryCanvas : MonoBehaviour {
	public Transform[] types;
	public GameObject itemPrefab;
	public GameObject canvas;
	private GameObject newItem;
	private InventoryItem newItemScript;
	private GameObject infoAlert;

	void Awake(){
		infoAlert = GameObject.FindGameObjectWithTag ("ItemInfo").transform.parent.gameObject;
		infoAlert.SetActive (false);
	}

	public void InitItemCanvas(Item[] items){
		infoAlert.SetActive (true);
		foreach (Transform panel in types) {
			for(int i = 0; i<panel.childCount;i++){
				Destroy (panel.GetChild (i).gameObject);
			}
		}

		foreach (Item item in items) {
			PlaceItem (item);
		}
		infoAlert.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PlaceItem(Item item){
		newItem = Instantiate (itemPrefab);
		newItem.GetComponent<InventoryItem>().InitItem (item);
		newItem.transform.SetParent(types [item.type]);
	}

	public void ShowCanvas(){
		if (canvas.activeSelf) {
			canvas.SetActive (false);
			Time.timeScale = 1;
		} else {
			canvas.SetActive (true);
			Time.timeScale = 0;
		}
		InitItemCanvas(GameObject.FindGameObjectWithTag ("Choo").GetComponent<Inventory> ().items.ToArray());
	}
}
