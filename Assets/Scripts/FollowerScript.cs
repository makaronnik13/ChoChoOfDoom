using UnityEngine;
using System.Collections;

public class FollowerScript : MonoBehaviour {
	public GameObject train;
	public GameObject followed;
	private float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		speed = train.GetComponent<WagonScript> ().GetSpeed();
		transform.position = Vector3.MoveTowards(transform.position, followed.transform.position, speed*Time.deltaTime);
	}

}
