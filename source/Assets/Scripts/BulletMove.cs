using UnityEngine;
using System.Collections;


public class BulletMove : MonoBehaviour {

	public float MoveSpeed = 40;	//Movementspeed of the bullet

	// Use this for initialization
	void Start () {

	}
	

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * Time.deltaTime * MoveSpeed);	//Moves the bullet
		Destroy (this.gameObject, 10);									//Auto destroys bullet after 10 seconds
	}
}
