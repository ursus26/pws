﻿using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public Transform Bullet;

	public float Cooldown = .1f;	//cooldown of shooting a bullet in miliseconds
	private float NextShot;


	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
		if (Time.time >= NextShot) {
			if (Input.GetKeyDown (KeyCode.Space) | Input.GetMouseButton (0)) {
				SpawnBullet ();
				NextShot = Time.time + Cooldown;
			}
		}

	}


	void SpawnBullet(){
		Instantiate(Bullet, transform.position, transform.rotation);	
	}
}
