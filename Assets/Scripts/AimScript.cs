using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AimScript : MonoBehaviour {

	public int type;
	private Image img;
	private bool activated = false;

	// Use this for initialization
	void Start () {
		Invoke ("HasntBeenShooted", 5);
		if (type == 1 || type == 2){
			img = GetComponent<Image> ();
		}
		if (type == 2){
			InvokeRepeating ("Load", 0, 0.0005f);
		}
	}

	void OnMouseDown() 
	{
		if (type == 0 || type == 2) {
			Activate ();
		}
		if (type == 1){
			InvokeRepeating ("Load", 0, 0.1f);
		}
		if (type == 2){
			CancelInvoke ("Load");
			Activate ();
		}
	}

	void OnMouseOver(){
		if (type == 1 && !activated){
			InvokeRepeating("Load", 0, 0.1f);
		}
	}

	void OnMouseExit(){
		if (type == 1 && activated){
			CancelInvoke("Load");
		}
	}

	// Update is called once per frame
	void Update () {
		//pc
		/*if (Input.GetMouseButton (0)) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit != null && hit.collider!=null){
				Debug.Log (hit.collider);
				if (hit.collider.gameObject == gameObject) {
					Activate ();
				}
			}

		}

		//mobile
		if (Input.touchCount > 0) {
			Debug.Log ("touch");
			foreach (Touch touch in Input.touches) {
				if(touch.phase == TouchPhase.Began && GetComponent<SpriteRenderer>().sprite.rect.Contains(touch.position)){
					Activate ();
				}
			}
		}
	*/
	}

	void HasntBeenShooted(){
		Destroy (gameObject);
	}

	void Activate(){
		Destroy (gameObject);
	}

	void Load(){
		if (type == 1) {
			img.fillAmount += 0.02f;
			if (img.fillAmount >= 1) {
				Activate ();
			}
		}
		if (type == 2) {
			img.gameObject.transform.localScale *= 0.99f;
			//if (img.fillAmount >= 1) {
			//	Activate ();
			//}
		}
	}
}
