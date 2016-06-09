using UnityEngine;
using System.Collections;

public class SelectPannelScript : MonoBehaviour {

	private Vector2 position;
	private RectTransform transform;
	private Rect rect;

	// Use this for initialization
	void Start () {
		transform = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		position = Input.mousePosition;
		transform.rect.Set (transform.rect.x, transform.rect.y, position.x-transform.rect.x, position.y-transform.rect.y);
	}
}
	