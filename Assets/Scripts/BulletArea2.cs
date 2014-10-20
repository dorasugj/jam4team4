using UnityEngine;
using System.Collections;

public class BulletArea2 : MonoBehaviour {
	Touch touch;
	void OnTriggerEnter2D (Collider2D c)
	{
		touch  =c.GetComponent<Touch> ();
		//Vector2 rebound2 = c.gameObject.rigidbody2D.velocity;
		//Debug.Log("rebound b " + rebound2);
		//rebound2.x = -rebound2.x;
		//Debug.Log("rebound a" + rebound2);
		//c.gameObject.rigidbody2D.velocity = rebound2;
		//Debug.Log("hit");
		
		touch.setY ();
	}
}
