using UnityEngine;
using System.Collections;


public class BulletMove : MonoBehaviour {

	public float MoveSpeed = 40;	//Movementspeed of the bullet
	private float AutoDestroyTime;

	// Use this for initialization
	void Start () {
		AutoDestroyTime = Time.time + 10;
	}
	

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * Time.deltaTime * MoveSpeed);	//Moves the bullet

		//Destroys bullet on the whole server after ten seconds
		if(Time.time >= AutoDestroyTime) {
			Network.Destroy(GetComponent<NetworkView>().viewID);
		}
	}
}
