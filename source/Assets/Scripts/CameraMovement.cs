using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject TargetObject; 		//Player object
	//public Vector3 TargetPosition;		//CameraTarget = the position of the player
	bool targetset = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(targetset == true) {

		Debug.Log ("Camera update");
		//Define the position of the cameratarget
		Vector3 TargetPosition = new Vector3 (TargetObject.transform.position.x, TargetObject.transform.position.y, TargetObject.transform.position.z - 10);

		//Move the camera
		transform.position = Vector3.Lerp (transform.position, TargetPosition, Time.deltaTime * 8);	
		//transform.eulerAngles = new Vector3(0f,0f,0f);

		}
	}		

	public void setCameraTarget(GameObject targetobject) {
		TargetObject = targetobject;
		if (TargetObject == null) {
			Debug.Log ("Target = null");
		} else {

		Debug.Log ("camera is set");
		}
		targetset = true;
	}


}
