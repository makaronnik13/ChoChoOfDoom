using UnityEngine;
using System.Collections;
using SimpleJSON;

public class RoadGenerator : MonoBehaviour {
	private JSONNode N;
	public TextAsset itemsTextAsset;
	private float size;
	private int road;
	private GameObject roadPart;

	public GameObject[] RoadPrefabs;
	// Use this for initialization
	void Start () {
		itemsTextAsset = Resources.Load ("jSONS/road") as TextAsset;

		Vector2 sprite_size = GetComponentInChildren<SpriteRenderer>().sprite.rect.size;
		Vector2 local_sprite_size = sprite_size / GetComponentInChildren<SpriteRenderer>().sprite.pixelsPerUnit;
		Vector3 world_size = local_sprite_size;
		world_size.x *= transform.lossyScale.x;
		world_size.y *= transform.lossyScale.y;

		//convert to screen space size
		Vector3 screen_size = 0.5f * world_size / Camera.main.orthographicSize;
		screen_size.y *= Camera.main.aspect;
		size = world_size.x;

		N = JSON.Parse(itemsTextAsset.text)[0];
		int i = N.AsArray[0].AsArray.Count;
		int j = 0;

		foreach(JSONNode roadLine in N.AsArray){
			foreach(JSONNode roadNode in roadLine.AsArray){
				road = roadNode.AsInt;
				if (road > 0) {
					roadPart = (GameObject)Instantiate (RoadPrefabs [road-1], new Vector3(size*j, size*i, 0), Quaternion.identity);
					roadPart.transform.SetParent (transform);
				}
				i--;
			}
			i = roadLine.AsArray.Count;
			j++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
