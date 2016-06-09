using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PalletButton : MonoBehaviour {
	public int type;

	public void Press(){
		GameObject.Find ("cursoirController").GetComponent<CursoirScript> ().SetBlockType (type, GetComponent<Image>().sprite);
		Debug.Log ("pressed");
	}
}
