using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform Player; 


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		MoveCamera ();
	}

	void MoveCamera(){
		var x = transform.position.x; 
		var y = transform.position.y;

		//x = Player.position.x;
		//y = Player.position.y;

		transform.position = new Vector2 (x, y);
	}
}
