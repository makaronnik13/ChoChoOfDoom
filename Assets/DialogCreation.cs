using UnityEngine;
using System.Collections;

public class DialogCreation : MonoBehaviour {

	public GameObject menu;
	private GameObject addingButton;
	private RectTransform menuTransform;
	public GameObject[] EmptyButtons;
	public GameObject[] LocationButtons;
	public GameObject[] ActionButtons;
	private GameObject[] AddingButtons;


	// Use this for initialization
	void Start () {
		menuTransform = menu.GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			menuTransform.position = new Vector2(Input.mousePosition.x+menuTransform.rect.width/2, Input.mousePosition.y-menuTransform.rect.height/2);
		}

		if (Input.GetMouseButtonDown (0)) {
			menuTransform.position = new Vector2 (1000, 1000);
		}
	}

	public void ReInitMenu(int clickType){
		for (int i=0; i<menu.transform.childCount;i++) {
			Destroy (menu.transform.GetChild(i).gameObject);
		}

		switch (clickType) {
		case 1:
			AddingButtons = EmptyButtons;
			break;

		case 2:
			AddingButtons = LocationButtons;
			break;
		case 3:
			AddingButtons = ActionButtons;
			break;
		}
		if(clickType!=0){
			foreach (GameObject button in AddingButtons) {
				addingButton = (GameObject)Instantiate (button);
				addingButton.transform.SetParent(menuTransform);
			}
		}
	}
}
