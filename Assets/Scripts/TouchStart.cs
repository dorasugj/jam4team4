using UnityEngine;
using System.Collections;

public class TouchStart : MonoBehaviour {

	//private float nextTime;
	public float interval = 1.0f;

	private float timer;
	private bool flag;

	private GameObject touchAudio;

	
	// Use this for initialization
	void Start() {
		timer = 0;
		flag = false;
	}
	
	// Update is called once per frame
	void Update() {
		timer += Time.deltaTime;
		if(timer > interval){
			renderer.enabled = !renderer.enabled;
			timer = 0;
		}
		if(flag){
			Debug.Log("test"+ timer);
			if(timer >0.3f){
				Debug.Log("test2"+ timer);
				Changescene();
			}
		}
	}
	void OnMouseDown() {
		timer = 0;
		flag = true;
	}

	void Changescene(){
		Application.LoadLevel("Main");
	}

}
