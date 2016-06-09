using UnityEngine;
using System.Collections;

public class RailwayCorner : MonoBehaviour {
	public MyArray[] ins;
	private WagonScript wagon;
	private int fromRotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		wagon = other.GetComponent<WagonScript> ();
		wagon.transform.position = transform.position;
		fromRotation = wagon.GetRotation() - 2;
		if (fromRotation < 0) {
			fromRotation += 4;
		}
		wagon.SwitchRotation (ins[fromRotation].outs);
	}
}

[System.Serializable]
public class MyArray{
	public int[] outs;
}