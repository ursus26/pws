﻿using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {

	private GameObject zObject;
	PlayerHealth playerHealth; 


	void Awake() {
	}


	void OnTriggerEnter2D(Collider2D other) {
		playerHealth = GameObject.Find(other.name).GetComponent<PlayerHealth>();


		if(other.tag == "Wall") {
			//playerHealth.TakeDamage(5);
			Network.Destroy(GetComponent<NetworkView>().viewID);
		}

		if(other.tag == "Player" && !networkView.isMine) {
			playerHealth.TakeDamage(5);
			Network.Destroy(GetComponent<NetworkView>().viewID);
		}
	}
}
