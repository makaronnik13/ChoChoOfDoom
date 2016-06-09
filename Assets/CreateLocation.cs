using UnityEngine;
using System.Collections;

public class CreateLocation : MonoBehaviour {
	
	public GameObject locationPrefab; 
	private GameObject newLocation;

	public void CreateLoc(){
		newLocation = (GameObject) Instantiate (locationPrefab);
		newLocation.transform.parent = GameObject.Find ("Canvas").transform;
	}
}
