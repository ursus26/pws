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


		if (Input.GetKey (KeyCode.D) | Input.GetKey (KeyCode.RightArrow)) {			//if D or Right arrow is pressed->move right in the world
			transform.Translate(Vector3.right * 4f * Time.deltaTime, Space.World);
		}
		
		if (Input.GetKey (KeyCode.A) | Input.GetKey (KeyCode.LeftArrow)) {			//if A or Left arrow is pressed->move left in the world
			transform.Translate(Vector3.right * -4f * Time.deltaTime, Space.World);
		}
		
		if (Input.GetKey (KeyCode.W) | Input.GetKey (KeyCode.UpArrow)) {			//if W or Up arrow is pressed->move up in the world
			transform.Translate(Vector3.up * 4f * Time.deltaTime, Space.World);
		}
		
		if (Input.GetKey (KeyCode.S) | Input.GetKey (KeyCode.DownArrow) ) {			//if S or Down arrow is pressed->move down in the world
			transform.Translate(Vector3.down * 4f * Time.deltaTime, Space.World);
		}


}
		



	void RotatePlayer(){
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;	//Difference of mousepos and playerpos
		difference.Normalize();																			//makes the sum of Vector3 = 1

		float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;						//Calculate the angle to rotate around
		transform.rotation = Quaternion.Euler(0, 0, rotation - 90);										//Rotates the player
	}
}
