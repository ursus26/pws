using UnityEngine;
using System.Collections;


[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

	public float rotationSpeed = 450;

	private Quaternion PlayerRotation;
	private CharacterController controller;
	private Camera cam;


	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		cam = Camera.main;
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
			transform.Translate(Vector3.forward * 5f * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.S) | Input.GetKey (KeyCode.DownArrow) ) {//if S or Down arrow is pressed->go down
			transform.Translate(Vector3.forward * -3f * Time.deltaTime);
		}
}

	void RotatePlayer(){
		Vector3 mousePos = Input.mousePosition;
		mousePos = cam.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));
		PlayerRotation = Quaternion.LookRotation (mousePos - new Vector3 (transform.position.x, 0, transform.position.z));


		//rotation
		transform.eulerAngles = Vector3.up * 
			Mathf.MoveTowardsAngle (transform.eulerAngles.y, PlayerRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);


	}
}
