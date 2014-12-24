using UnityEngine;
using System.Collections;

//Vector3 tmpPos = transform.position; // Store all Vector3 
//tmpPos.z = 1.0f; // example assign individual fox Y axe 
//transform.position = tmpPos; // Assign back all Vector3

public class BulletMove : MonoBehaviour {

	public float MoveSpeed = 40;	//Movementspeed of the bullet

	// Use this for initialization
	void Start () {

	}
	

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * Time.deltaTime * MoveSpeed);	//Moves the bullet
		Destroy (this.gameObject, 5);									//Destroys bullet after 5 seconds
	}
}
