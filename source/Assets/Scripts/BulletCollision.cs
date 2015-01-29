using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {

	PlayerHealth playerHealth; 

	void OnTriggerEnter2D(Collider2D other) {
		playerHealth = GameObject.Find(other.name).GetComponent<PlayerHealth>();


		if(other.tag == "Wall") {	//When bullet hits the wall
			NetworkManager.Instance.DestroyNetworkObject(gameObject);
		}

		if(other.tag == "Player" && !networkView.isMine) { //When bullet hits an player and is not himself
			playerHealth.TakeDamage(20);
			NetworkManager.Instance.DestroyNetworkObject(gameObject);
		}
	}
}
