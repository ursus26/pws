using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public float test;
	public float a;
	public float b;
	public float c;


	public float angle;
	Vector2 dir;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		MovePlayer ();
		RotatePlayer ();
	}

	void MovePlayer(){
		if (Input.GetKey (KeyCode.D) | Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate(Vector2.right * 5f * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.A) | Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate(Vector2.right * -5f * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.W) | Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate(Vector2.up * 5f * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.S) | Input.GetKey (KeyCode.DownArrow) ) {
			transform.Translate(Vector2.up * -5f * Time.deltaTime);
		}
}

	void RotatePlayer(){

	/*

		a = Input.mousePosition.x - transform.position.x;
		b = Input.mousePosition.y - transform.position.y;
		c = Mathf.Cos (a);
		test = Mathf.Sin (b);
		a = c * test;


		b = Input.mousePosition.y - a;
		test = Input.mousePosition.x - c;

		if (b == 0) {

		} else {
			c = Mathf.Sin (b) * 4; // Mathf.Cos (test);
			transform.Rotate (0, 0, -c);
		}




		a = Input.mousePosition.y;
		c = Input.mousePosition.x;

*/
		dir = Input.mousePosition - transform.position;
		angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


		}



}