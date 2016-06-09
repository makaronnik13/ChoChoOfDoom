using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour {

	public Vector3 windVector;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + windVector*Time.deltaTime;
	}
}
