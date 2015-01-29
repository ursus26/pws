using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public Transform Bullet;
	public GameObject shootPosition;
	public float Cooldown = .1f;	//cooldown of shooting a bullet in miliseconds
	private float NextShot;			//Time for the next shot



	// Use this for initialization
	void Awake () {
		shootPosition = GameObject.Find("BulletSpawn") as GameObject;
	}


	// Update is called once per frame
	void Update () {

		if(!networkView) {
			return;
		}


		if (Time.time >= NextShot) {
			if (Input.GetMouseButton (0)) {
				SpawnBullet ();
				NextShot = Time.time + Cooldown;
			}
		}

	}//End of function


	void SpawnBullet(){
		Network.Instantiate(Bullet, shootPosition.transform.position, transform.rotation, 0);
	}

}//End of class
