using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public Transform Bullet;

	public float Cooldown = .1f;	//cooldown of shooting a bullet in miliseconds
	private float NextShot;			//Time for the next shot


	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () {

		if (Time.time >= NextShot) {
			if (Input.GetMouseButton (0)) {
				SpawnBullet ();
				NextShot = Time.time + Cooldown;
			}
		}

	}//End of function


	void SpawnBullet(){
		Instantiate(Bullet, transform.position, transform.rotation);	//Spawns a bullet	
	}

}//End of class
