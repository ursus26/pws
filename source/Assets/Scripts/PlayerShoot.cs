using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public Transform BulletPrefab;		//Prefab of the bullet
	public GameObject shootPosition;	//Spawn position of bullet
	public float Cooldown = .1f;		//cooldown of shooting a bullet in miliseconds
	private float NextShot;			//Time for the next shot


	void Awake () {
		shootPosition = GameObject.Find("BulletSpawn") as GameObject;
	}


	// Update is called once per frame
	void Update () {
		if (Time.time >= NextShot) {
			if (Input.GetMouseButton (0)) {	//if left mouse button has been pressed
				SpawnBullet ();	//Spawn the bullet if left mouse button has been pressed
				NextShot = Time.time + Cooldown;//delay between the next shot
			}
		}
	}//End of function


	void SpawnBullet(){
		Network.Instantiate(BulletPrefab, shootPosition.transform.position, transform.rotation, 0);
	}

}//End of class
