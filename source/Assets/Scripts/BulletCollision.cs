using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {

	private GameObject zObject;
	PlayerHealth ph; 


	void start() {


	}


	void OnTriggerEnter2D(Collider2D other) {
		//zObject = other.gameObject;

		if(other.tag == "Wall") {
			//zObject.GetComponent<PlayerHealth>().TakeDamage(5);

			Network.Destroy(GetComponent<NetworkView>().viewID);
		}

		if(other.tag == "Player") {
			other.GetComponent<PlayerHealth>().TakeDamage(5);
			Network.Destroy(GetComponent<NetworkView>().viewID);
		}
	}
}
