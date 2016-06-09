using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour {

	private string text;
	private GameObject info;

	// Use this for initialization
	void Awake() {
		info = GameObject.FindGameObjectWithTag ("ItemInfo");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitItem(Item item){
		GetComponent<Image> ().sprite = item.img;
		if (item.num == 1) {
			GetComponentInChildren<Text> ().text = "";
		} else {
			GetComponentInChildren<Text> ().text = item.num.ToString();
		}
		text = item.text;
	}

	public void SetText(){
		info.GetComponent<Text>().text = text;
		info.transform.parent.gameObject.SetActive (true);
	}
}
