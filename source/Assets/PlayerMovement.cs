﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		if (Input.GetKey (KeyCode.D) | Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate(Vector2.right * 5f * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.A) | Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate(Vector2.right * -5f * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.W) | Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate(Vector2.up * 5f * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.S) | Input.GetKey (KeyCode.DownArrow) ) {
			transform.Translate(Vector2.up * -5f * Time.deltaTime);
		}
}



