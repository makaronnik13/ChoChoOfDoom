﻿using UnityEngine;
using System.Collections;

public class BattleTrain : MonoBehaviour {
	public float speed;
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x+speed*Time.deltaTime, transform.position.y, transform.position.z);
	}
}
