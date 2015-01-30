using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public Transform Bullet;		//Bullet prefab
	public GameObject shootPosition;//Position the bullet spawns
	public float Cooldown = .1f;	//cooldown of shooting a bullet in miliseconds
	private float NextShot;			//Time for the next shot


	// Use this for initialization
	void Awake () {
		shootPosition = GameObject.Find("BulletSpawn") as GameObject;
	}


	// Update is called once per frame
	void Update () {
		if (Time.time >= NextShot) {

			if (Input.GetMouseButtonDown (0)) {//Shoots the bullet when left mouse button has been pressed.
				SpawnBullet ();
				NextShot = Time.time + Cooldown;
			}

		}

	}//End of function


	void SpawnBullet(){
		Network.Instantiate(Bullet, shootPosition.transform.position, transform.rotation, 0);	//Spawns bullet on the network
		Audio.Instance.PlayGunShot();															//Plays gunshot
	}

}//End of class
