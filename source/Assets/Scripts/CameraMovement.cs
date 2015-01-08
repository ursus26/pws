using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform Player; 			//Player object
	private Vector3 CameraTarget;		//CameraTarget = the position of the player

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		CameraTarget = new Vector3 (Player.position.x, Player.position.y, Player.position.z - 10);//Define the position of the cameratarget
		transform.position = Vector3.Lerp (transform.position, CameraTarget, Time.deltaTime * 8);			//Move the camera
	}																										


}
