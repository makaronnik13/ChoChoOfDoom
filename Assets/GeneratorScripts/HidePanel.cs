using UnityEngine;
using System.Collections;

public class HidePanel : MonoBehaviour {

	public GameObject panel;
	// Use this for initialization
	public void Hide(){
		panel.SetActive (!panel.activeSelf);
	}
}
