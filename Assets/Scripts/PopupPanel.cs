using UnityEngine;
using System.Collections;

public class PopupPanel : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		HideIfClickedOutside (gameObject);
	}

	private void HideIfClickedOutside(GameObject panel) {
		//for mobile if (Input.touches.Length>0 && panel.activeSelf 
		if (Input.GetMouseButton(0) && panel.activeSelf){
			panel.SetActive(false);
		}
	}
}
