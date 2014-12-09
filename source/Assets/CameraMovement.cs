using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private Transform Player; 
	private Vector3 CameraTarget;
	public float CameraHeight = 10;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
		CameraTarget = new Vector3 (Player.position.x, Player.position.y, Player.position.z - CameraHeight);
		transform.position = Vector3.Lerp (transform.position, CameraTarget, Time.deltaTime * 8);
	}


}
