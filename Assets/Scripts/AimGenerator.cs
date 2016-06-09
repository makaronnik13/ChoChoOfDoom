using UnityEngine;
using System.Collections;

public class AimGenerator : MonoBehaviour {

	public GameObject aim1;
	public GameObject aim2;
	public GameObject aim3;
	public Transform aimCanvas;
	private GameObject newAim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GenerateAims(Bounds bound){
		for (int i = 0; i < 3; i++) {
			newAim = (GameObject)Instantiate (aim1, new Vector3 (Random.Range (bound.min.x+bound.size.x/5, bound.max.x-bound.size.x/5), Random.Range (bound.min.y+bound.size.y/5, bound.max.y-bound.size.y/5), 0), Quaternion.Euler(Vector3.zero));
			newAim.transform.SetParent (aimCanvas);
		}

		for (int i = 0; i < 1; i++) {
			newAim = (GameObject)Instantiate (aim2, new Vector3 (Random.Range (bound.min.x+bound.size.x/5, bound.max.x-bound.size.x/5), Random.Range (bound.min.y+bound.size.y/5, bound.max.y-bound.size.y/5), 0), Quaternion.Euler(Vector3.zero));
			newAim.transform.SetParent (aimCanvas);
		}

		for (int i = 0; i < 1; i++) {
			newAim = (GameObject)Instantiate (aim3, new Vector3 (Random.Range (bound.min.x+bound.size.x/5, bound.max.x-bound.size.x/5), Random.Range (bound.min.y+bound.size.y/5, bound.max.y-bound.size.y/5), 0), Quaternion.Euler(Vector3.zero));
			newAim.transform.SetParent (aimCanvas);
		}
	}
}
