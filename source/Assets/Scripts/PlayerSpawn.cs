using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {
	public Transform player;
	PlayerHealth playerHealth;
	PlayerMovement playerMovement;
	PlayerShoot playerShoot;
	GameObject[] spawnAreas;

	// Use this for initialization
	void Awake () {
		playerHealth = GetComponent<PlayerHealth>();
		playerMovement = GetComponent<PlayerMovement>();
		playerShoot = GetComponentInChildren<PlayerShoot>();

	}
	
	// Update is called once per frame
	public void Respawn(){
		renderer.enabled = false;																					// Maakt de player tijdelijk onzichtbaar
		spawnAreas = GameObject.FindGameObjectsWithTag("Ground"); 													// Kijkt naar mogelijke plekken om te spawnen en zet ze in een array
		int randomNumber = Random.Range(0, (int)spawnAreas.Length);													// Genereert een willekeurig getal ..
		GameObject spawnPoint = spawnAreas [randomNumber];															// .. en gebruikt die om een willekeurig punt uit de array te pakken

		transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, -1);		// Verplaatst de speler naar dat willekeurige punt
		playerHealth.isDead = false;																				// Maakt de speler voor het systeem weer levend
		renderer.enabled = true;																					// Maakt de speler weer zichtbaar

		playerHealth.SetHealth (100);																				// Geeft weer 100 levens aan de speler
		playerMovement.enabled = true;
		playerShoot.enabled = true;
	}


}
