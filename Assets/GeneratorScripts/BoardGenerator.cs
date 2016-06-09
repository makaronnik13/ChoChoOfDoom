using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using UnityEditor;
using System.IO;
using System;

public class BoardGenerator : MonoBehaviour {

	public GameObject roadButton;
	public GameObject board;
	public Text _i;
	public Text _j;
	private TextAsset json;
	private int x;
	private int y;

	public void GenerateBoard(){
		foreach(Transform child in board.transform){
			Destroy (child.gameObject);
		}
		x = int.Parse(_i.text);
		y = int.Parse(_j.text);
		board.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(_i.text);
		for (int i = 0; i < x; i++) {
			for (int j = 0; j < y; j++) {
				Instantiate (roadButton).transform.SetParent (board.transform);
			}
		}
	}

	public void Save(){
		JSONNode node = new JSONClass();
			
		JSONArray raws = new JSONArray();
		for (int i = 0; i < x; i++) {
			JSONArray line = new JSONArray();
			for (int j = 0; j < y; j++) {
				line.Add(board.transform.GetChild(j*x+i).GetComponent<RoadButton>().value.ToString());
			}
			raws [i] = line;
		}

		node["road"] = raws;

		var sr = File.CreateText(Application.dataPath+"/Resources/jSONS/road.json");
		sr.Write(node.ToString());
		sr.Close();

		Debug.Log ("huray");
	}

	public void Load(){
		GameObject button;
		json = Resources.Load ("jSONS/road") as TextAsset;
		JSONArray matrix= JSON.Parse(json.text)[0].AsArray;

		foreach(Transform child in board.transform){
			Destroy (child.gameObject);
		}

		board.GetComponent<GridLayoutGroup>().constraintCount = matrix.Count;

		//Debug.Log (matrix[0].AsArray.Count);
		for (int i = 0; i < matrix.Count; i++) {
			for (int j = 0; j < matrix[0].AsArray.Count; j++) {
				button = Instantiate (roadButton);
				button.transform.SetParent (board.transform);
				Debug.Log (matrix [i].AsArray[j].AsInt);
				button.GetComponent<RoadButton> ().Init(matrix [j].AsArray[i].AsInt);
			}
		}
	}
}
