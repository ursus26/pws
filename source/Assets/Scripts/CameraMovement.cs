using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject TargetObject; 		//Player object
	//public Vector3 TargetPosition;		//CameraTarget = the position of the player
	bool TargetSet = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(TargetSet == true) {

			//Define the position of the cameratarget
			Vector3 TargetPosition = new Vector3 (TargetObject.transform.position.x, TargetObject.transform.position.y, TargetObject.transform.position.z - 10);

			//Move the camera
			transform.position = Vector3.Lerp (transform.position, TargetPosition, Time.deltaTime * 8);	
		}
	}		

	public void setCameraTarget(GameObject targetobject) {
		TargetObject = targetobject;
		TargetSet = true;
	}


}
