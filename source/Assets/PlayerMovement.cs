using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	//variables used in this class
	public float dx;
	public float dy;
	public float LastMousePosx;
	public float LastMousePosy;
	public float angle;

	// Use this for initialization
	void Start () {
		LastMousePosx = Input.mousePosition.x;
		LastMousePosy = Input.mousePosition.y;
	}
	
	// Update is called once per frame
	void Update () {
		MovePlayer ();
		RotatePlayer ();
	}

	void MovePlayer(){
		if (Input.GetKey (KeyCode.D) | Input.GetKey (KeyCode.RightArrow)) {//if D or Right arrow is pressed->go right
			transform.Translate(Vector2.right * 5f * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.A) | Input.GetKey (KeyCode.LeftArrow)) {//if A or Left arrow is pressed->go left
			transform.Translate(Vector2.right * -5f * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.W) | Input.GetKey (KeyCode.UpArrow)) {//if W or Up arrow is pressed->go up
			transform.Translate(Vector2.up * 5f * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.S) | Input.GetKey (KeyCode.DownArrow) ) {//if S or Down arrow is pressed->go down
			transform.Translate(Vector2.up * -5f * Time.deltaTime);
		}
}

	void RotatePlayer(){
		//calculate the difference of the mouse movement in y and x direction 
		dx = (Input.mousePosition.x - LastMousePosx) / Screen.width;
		dy = (Input.mousePosition.y - LastMousePosy) / Screen.height;
		
		//calculate the angle the player has to rotate
		if(dx == 0) { //check if dx == 0 or else there will be an error because of deviding by 0
			dx = 1;	
		} 
		angle = Mathf.Atan(dy/dx);
		
		//rotate player
	
		transform.rotation = Quaternion.Euler(0,0,angle);
		
		//save current frame mouse position
		LastMousePosx = Input.mousePosition.x;
		LastMousePosy = Input.mousePosition.y;
		
	}



}
