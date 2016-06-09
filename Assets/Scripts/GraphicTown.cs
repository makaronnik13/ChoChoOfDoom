using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GraphicTown : MonoBehaviour {
	public GameObject dialog;
	public LocationsBase locations;
	public Image locationImage;
	public Text locationText;
	public Transform actionsHolder;
	public GameObject buttonPrefab;
	private GameObject newButton;

	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowDialog(int num){
		Location location = locations.GetLocationById (num);
		locationImage.sprite = location.img;
		locationText.text = location.text;
		foreach (Transform child in actionsHolder) {
			Destroy(child.gameObject);
		}

		foreach(Action action in location.actions){
			newButton = Instantiate (buttonPrefab);
			newButton.GetComponentInChildren<ActionButton> ().SetButton (action);
			newButton.transform.SetParent (actionsHolder);
		}
		dialog.SetActive (true);
	}
}
