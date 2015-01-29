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
		/*var temp = transform.position;
		var ypos = transform.position.y;
		var xpos = transform.position.x;
		var angle = transform.eulerAngles.y;
		var angle2 = transform.eulerAngles.x;
		Debug.Log(angle + " " +angle2);
		ypos = transform.position.y + Mathf.Sin(angle) * (renderer.bounds.size.y / 2 + .02f);
		xpos = transform.position.x + Mathf.Cos(angle2) * (renderer.bounds.size.x / 2 + .02f);
		temp = new Vector3(xpos, ypos, transform.position.z);*/


		//Instantiate(Bullet, transform.position, transform.rotation);	//Spawns a bullet	
		//Network.Instantiate(Bullet, transform.position, transform.rotation, 0);
		Network.Instantiate(Bullet, shootPosition.transform.position, transform.rotation, 0);
	}

}//End of class
