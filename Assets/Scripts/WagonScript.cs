using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class WagonScript : MonoBehaviour {

	public float baseSpeed = 0.3f;
	private float speed;
	private int rotation = 0;
	private Quaternion neededRotation;
	private bool RotationSide;
	private int fromRotation;
	public Animator wayButton;
	public Slider fuelSlider;
	public Text fuelText;
	private int fuel = 25;
	public int baseTimeToRelax = 10000;
	public float dangerForce = 0.7f;
	public float explosionChance = 0.1f;
	private bool exploded = false;
	private int timeToRelax;
	public float timeToRepair = 3;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		timeToRelax = baseTimeToRelax;
		speed = baseSpeed*fuelSlider.value;
		MoveForward ();
		InvokeRepeating ("SlowDown",0,0.1f);
		InvokeRepeating ("CheckEngine",0,1f);
		fuelText.text = fuel.ToString();
	}

	private void SlowDown(){
		if (speed > 0) {
			speed -= baseSpeed / timeToRelax;
		} else {
			speed = 0;
		}
		fuelSlider.value = speed/baseSpeed;
	}

	public int GetRotation(){
		return rotation;
	}

	private void CheckEngine(){
		if ((fuelSlider.value > dangerForce) && (Random.value<explosionChance)) {
			Explode ();
		}
	}

	void Explode(){
		fuelSlider.image.color = Color.red;
		exploded = true;	
		timeToRelax = baseTimeToRelax / 5;
		Invoke ("Repair", timeToRepair);
	}

	void Repair(){
		fuelSlider.image.color = Color.yellow;
		exploded = false;
		timeToRelax = baseTimeToRelax;
	}

	// Update is called once per frame
	void Update () {
		MoveForward ();
		RotateTo ();
	}

	public void CheckInput(){
		RotationSide = !wayButton.GetBool("Way");
		wayButton.SetBool ("Way", RotationSide);
	}

	public float GetSpeed(){
		return speed;
	}

	public void SetSpeed(float _speed){
		speed = _speed;
	}

	public void AddFuel(){
		if ((fuel > 0) && (fuelSlider.value<0.9f)&&(!exploded)){
			fuel--;
			fuelSlider.value += 0.1f;
			speed = fuelSlider.value * baseSpeed;
			fuelText.text = fuel.ToString();
		}
	}

	public void SwitchRotation(int[] sides){
		if (sides.Length == 1) {
			rotation = sides [0];
		} else {
			if (RotationSide) {
				rotation = sides [1];
			} else {
				rotation = sides [0];
			}
		}

		SetRotation ();
	}

	void RotateTo(){
		transform.rotation = Quaternion.RotateTowards(transform.rotation, neededRotation, Time.deltaTime * rotationSpeed*speed);
	}

	void SetRotation(){
		neededRotation = Quaternion.Euler(new Vector3(0,0,360-90*rotation));
	}

	void MoveForward(){
		switch (rotation) {
		case 0:
			MoveUp ();
			break;
		case 1:
			MoveRight ();
			break;
		case 2:
			MoveDown ();
			break;
		case 3:
			MoveLeft ();
			break;
		}
	}

	void MoveLeft(){
		transform.position = transform.position + Vector3.left*speed*Time.deltaTime;
	}

	void MoveUp(){
		transform.position = transform.position + Vector3.up*speed*Time.deltaTime;
	}

	void MoveRight(){
		transform.position = transform.position - Vector3.left*speed*Time.deltaTime;
	}

	void MoveDown(){
		transform.position = transform.position - Vector3.up*speed*Time.deltaTime;
	}
}
