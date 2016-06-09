using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public Transform trainTransform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(trainTransform.position.x, trainTransform.position.y, -10);
	}
}
