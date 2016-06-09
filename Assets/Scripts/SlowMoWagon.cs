using UnityEngine;
using System.Collections;

public class SlowMoWagon : MonoBehaviour {
	public float timeScale;
	bool generated = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((Mathf.Abs(transform.position.x - Camera.main.transform.position.x)<0.3f)&&!generated) {
			Time.timeScale = timeScale;
			generated = true;
			if (timeScale < 1) {
				GetComponentInParent<AimGenerator> ().GenerateAims (transform.parent.GetComponent<SpriteRenderer>().bounds);
			}
		}
	}
}
