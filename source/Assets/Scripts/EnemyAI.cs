using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float speed = 4f;
	private GameObject player;


	// Use this for initialization
	void Start () {
	player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		RotateToPlayer();
	}


	void Move() {
		transform.Translate(Vector3.up * 3f * Time.deltaTime);
	}


	void RotateToPlayer() {

		Vector3 difference = player.transform.position - transform.position;	//Difference of mousepos and playerpos
		difference.Normalize();													//makes the sum of Vector3 = 1
		
		float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;	


		transform.rotation = Quaternion.Euler(0, 0, rotation - 90);	
	}
}
