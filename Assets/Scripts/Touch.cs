using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {


	private bool isTouch = false;
	private bool shoot;
	private bool yflag = false;

	private Vector2 selfPos;
	private Vector2 selfPos1;
	private Vector2 startPos;
	private Vector2 endPos;
	private Vector3 screenPos;
	private Vector3 offset;
	private Vector3 currentPos;

	public GameObject student;
	private GameObject student_clone;
	private int Power;
	private bool energy = false;
	private Vector2 setValue;

	public GameObject target;
	GameManeger gameManeger;

	bool gameEnd = false;

	void OnMouseDown()
	{

		isTouch = true;
		screenPos = Camera.main.WorldToScreenPoint (transform.position);

		float x = Input.mousePosition.x;
		float y = Input.mousePosition.y;
		offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (x, y, screenPos.z));

		if(gameEnd){
				Debug.Log("maiub");
				Application.LoadLevel("Result");
		}
	}

	void OnMouseDrag()
	{
		float x = Input.mousePosition.x;
		float y = Input.mousePosition.y;

		Vector3 currentScreenPos = new Vector3 (x, y, screenPos.z);
		currentPos = Camera.main.ScreenToWorldPoint (currentScreenPos) + offset;

		if(student){
			student.transform.position = currentPos;
		}
	}
	float GetAim(Vector2 p1, Vector2 p2) {
		float dx = p2.x - p1.x;
		float dy = p2.y - p1.y;
		float rad = Mathf.Atan2(dy, dx);
		return rad * Mathf.Rad2Deg;
	}

	// Use this for initialization
	void Start () {
		isTouch = false;
		shoot = false;
		gameManeger = target.GetComponent<GameManeger> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(isTouch && Input.GetMouseButtonDown(0)){

			startPos = Input.mousePosition;
			Debug.Log ("start"+startPos);
			selfPos1 = Camera.main.WorldToScreenPoint(startPos);
			//Destroy(student);
			//student_clone = Instantiate(student,transform.position,transform.rotation) as GameObject;
		}else if(isTouch && Input.GetMouseButtonUp(0)){
			//Destroy(student);
			endPos = Input.mousePosition;
			selfPos = Camera.main.ScreenToWorldPoint(new Vector2(
				endPos.x,
				endPos.y
				));
			Debug.Log ("start"+selfPos);
			float dir = GetAim (startPos, endPos);
			Vector2 distance = new Vector2 (endPos.x - startPos.x, endPos.y - startPos.y);
			float dis = distance.magnitude;

			Debug.Log ("rad"+Mathf.Deg2Rad * dir);



			setValue.x = -Mathf.Cos (Mathf.Deg2Rad * dir) * (dis/10);
			setValue.y = -Mathf.Sin (Mathf.Deg2Rad * dir) * (dis/10);
			//student.rigidbody2D.velocity = setValue;
			//GameObject student_clone = Instantiate (student, selfPos, transform.rotation) as GameObject;
			student.rigidbody2D.velocity = setValue;
			energy = true;
			//Debug.Log ("setValue"+student.rigidbody2D.velocity);
		}

		if (energy) {
			if(!yflag){
				setValue.y = setValue.y-0.05f;
			}else if(yflag){
				setValue.y = setValue.y+0.05f;
			}
			student.rigidbody2D.velocity = setValue;
			Debug.Log ("x   "+student.rigidbody2D.velocity.x);
			if(student.rigidbody2D.velocity.y<2.0f && student.rigidbody2D.velocity.y>-2.0f){
				setValue.y = 0f;
				setValue.x = 0f;
				student.rigidbody2D.velocity = setValue;
				energy = false;
				gameEnd = true;
			}
		}




		if (!shoot) {
			Debug.Log("end");
			isTouch = false;
			shoot = true;
		}

		if (gameEnd) {
			selfPos = Camera.main.ScreenToWorldPoint(transform.position);
						gameManeger.setValue (transform.position);
				}

	}

	public void setX(){
		setValue.x = -setValue.x;
	}
	public void setY(){
		setValue.y = -setValue.y;
		yflag = !yflag;
	}

	public void setStop(){
		setValue.y = 0f;
		setValue.x = 0f;
		student.rigidbody2D.velocity = setValue;
	}
}
