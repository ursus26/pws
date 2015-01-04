using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public Transform Bullet;

	public float Cooldown = .1f;	//cooldown of shooting a bullet in miliseconds
	private float NextShot;			//Time for the next shot
	bool LockAction = false;


	// Use this for initialization
	void Start () {
		LockAction = false;
	}


	// Update is called once per frame
	void Update () {
		if(LockAction == false) {

			if (Time.time >= NextShot) {
				if (Input.GetKeyDown (KeyCode.Space) | Input.GetMouseButton (0)) {
					SpawnBullet ();
					NextShot = Time.time + Cooldown;
				}
			}

		}//end of if(LockAction == false)
	}//End of function


	void SpawnBullet(){
		Instantiate(Bullet, transform.position, transform.rotation);	//Spawns a bullet	
	}

	public void setLockActionTrue() {
		LockAction = true;
	}

	public void setLockActionFalse() {
		LockAction = false;
	}
}
