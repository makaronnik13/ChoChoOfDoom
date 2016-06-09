using UnityEngine;
using System.Collections;

public class StopperScript : MonoBehaviour {
	private WagonScript wagon;
	public GameObject townCanvas;

	void Start(){
		//townCanvas = GameObject.FindGameObjectWithTag ("TownCanvas");
	}

	void OnTriggerEnter2D(Collider2D other) {
		wagon = other.GetComponent<WagonScript> ();
		wagon.transform.position = transform.position;
		wagon.SetSpeed (0);
		townCanvas.SetActive (true);
	}
}
