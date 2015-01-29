using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {

	PlayerHealth playerHealth; 

	void Awake() {
	}


	void OnTriggerEnter2D(Collider2D other) {
		playerHealth = GameObject.Find(other.name).GetComponent<PlayerHealth>();


		if(other.tag == "Wall") {
			//playerHealth.TakeDamage(5);
			//Network.Destroy(GetComponent<NetworkView>().viewID);
			NetworkManager.Instance.DestroyNetworkObject(gameObject);
		}

		if(other.tag == "Player" && !networkView.isMine) {
			playerHealth.TakeDamage(20);
			NetworkManager.Instance.DestroyNetworkObject(gameObject);
		}
	}
}
