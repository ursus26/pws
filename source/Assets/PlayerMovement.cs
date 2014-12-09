using UnityEngine;
using System.Collections;



public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		MovePlayer ();
		RotatePlayer ();
	}

	void MovePlayer(){
		if (Input.GetKey (KeyCode.D) | Input.GetKey (KeyCode.RightArrow)) {//if D or Right arrow is pressed->go right
			transform.Translate(Vector3.right * 3f * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.A) | Input.GetKey (KeyCode.LeftArrow)) {//if A or Left arrow is pressed->go left
			transform.Translate(Vector3.right * -3f * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.W) | Input.GetKey (KeyCode.UpArrow)) {//if W or Up arrow is pressed->go up
			transform.Translate(Vector3.up * 5f * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.S) | Input.GetKey (KeyCode.DownArrow) ) {//if S or Down arrow is pressed->go down
			transform.Translate(Vector3.down * 3f * Time.deltaTime);
		}
}


	void RotatePlayer(){
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		difference.Normalize();

		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, rotZ - 90);
	}
}
