using UnityEngine;
using System.Collections;

public class title : MonoBehaviour {
	void OnMouseDown() {
		Debug.Log("maiub");
		Application.LoadLevel("Main");
	}
}