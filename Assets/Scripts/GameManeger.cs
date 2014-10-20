using UnityEngine;
using System.Collections;

public class GameManeger : MonoBehaviour {
	
	Vector2 size = new Vector2(4,6);
	float x = Screen.width ;
	float y = Screen.height;
	Vector2 size2;
	Vector2 position;
	// Use this for initialization
	void Start () {
	
	}

	public void setValue(Vector2 x){
				position = x;
		Debug.Log (position);
		}
	
	// Update is called once per frame
	void Update () {
	
	}
}
