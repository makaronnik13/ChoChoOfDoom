using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour {
	public Text buttonText;
	private bool active = true;
	public GameObject reqPrefab;
	private GameObject newReq;
	public Transform reqHolder;
	private int locationToGo;
	private bool reqIs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetButton(Action action){
		locationToGo = action.locationId;
		buttonText.text = action.text;
		foreach (Requarement req in action.requarements) {
			reqIs = IfReqarement (req);
			active = active && reqIs;
			newReq = Instantiate (reqPrefab);
			newReq.GetComponent<RequarementPrefab> ().SetRequarement (req);
			newReq.transform.SetParent (reqHolder);
		}
		if (!active) {
			if(action.type){
				GetComponent<Button> ().interactable = false;
			}
			else{
				gameObject.SetActive (false);
			}
		}
	}

	public void GoToLocation(){
		GetComponentInParent<GraphicTown> ().ShowDialog (locationToGo);
		//add inventory changing
	}

	private bool IfReqarement(Requarement req){
		int itemNum = GameObject.FindGameObjectWithTag ("Choo").GetComponent<Inventory> ().ItemNum (req.itemId);
		switch (req.req){
		case "<":
			if (itemNum < req.num) {
				return true;
			}
			break;

		case "=":
			if (itemNum == req.num) {
				return true;
			}
			break;

		case ">":
			if (itemNum > req.num) {
				return true;
			}
			break;

		default:
			return false;
		}
		return false;
	}
}
