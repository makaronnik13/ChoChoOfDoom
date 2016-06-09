using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float cameraSpeed = 5;
	public float maxField = 140;
	public float minField = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x+Input.GetAxis("Horizontal")*cameraSpeed, transform.position.y+Input.GetAxis("Vertical")*cameraSpeed, transform.position.z);
		Camera.main.fieldOfView+=Input.GetAxis("Mouse ScrollWheel");
		if (Camera.main.fieldOfView > 140)
			Camera.main.fieldOfView = 140;
		if (Camera.main.fieldOfView < 20)
			Camera.main.fieldOfView = 20;
	}
}
