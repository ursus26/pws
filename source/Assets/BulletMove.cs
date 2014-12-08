using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {
	private float MoveSpeed = 100;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Moves the bullet
		transform.Translate (Vector3.forward * Time.deltaTime * MoveSpeed);

		//Destroys bullet after 5 seconds
		Destroy (this.gameObject, 5);
	}
}
