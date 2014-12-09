using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private Transform Player; 			//Player object
	private Vector3 CameraTarget;		//CameraTarget = the position of the player
	public float CameraHeight = 10;		//The height of the camera above the scene

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").transform;		//Finds the player object
	}
	
	// Update is called once per frame
	void Update () {
		CameraTarget = new Vector3 (Player.position.x, Player.position.y, Player.position.z - CameraHeight);//Define the position of the cameratarget
		transform.position = Vector3.Lerp (transform.position, CameraTarget, Time.deltaTime * 8);			//Move the camera
	}																										


}
