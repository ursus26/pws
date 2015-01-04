using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;                            // Begin health
	public int currentHealth;                                   // Huidige health
	public Slider healthSlider;                                 // De health bar
	public Text healthText;										// Tekst van de HUD die zegt hoeveel procent iemand heeft
	public Image damageImage;                                   // Rode flash bij damage
	public float flashSpeed = 5f;                               // Hoe snel de damage image weer wegvaagt
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // Kleur van de damage flash
	
	
	PlayerMovement playerMovement; 
	PlayerShoot playerShoot;       
	PlayerSpawn playerSpawn;
	EnemyAI enemyAI;
	public bool isDead;                                         // Dood ja/nee
	public bool damaged;                                        // Op dit moment damage ja/nee
	
	
	void Awake ()
	{
		playerMovement = GetComponent <PlayerMovement> ();
		playerShoot = GetComponentInChildren <PlayerShoot> ();
		playerSpawn = GetComponent<PlayerSpawn> ();
		enemyAI = GetComponent<EnemyAI> ();
		
		// Set the initial health of the player.
		currentHealth = startingHealth;							// Zet huidige health naar max
		healthSlider.value = currentHealth;						// Laat dit zien in de bar ..
		healthText.text = currentHealth.ToString() + "%";		// .. en als getal
	}
	
	void Update ()
	{
		// Wanneer de speler damage krijgt
		if(damaged)
		{
			// Geef de damage image
			damageImage.color = flashColour;
		}
		// Anders
		else
		{
			// Vaag het weg
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		
		// En dan wordt er geen damage meer gedaan
		damaged = false;
	}
	
	
	public void TakeDamage (int amount)
	{
		// Krijgt op dit moment damage
		damaged = true;
		
		// Haal health er af
		if (currentHealth > 0) {
			currentHealth -= amount;
		}
		
		// Laat de verandering zien in de HUD
		SetHealth (currentHealth);
				
		// Als health klein of gelijk aan 0 is
		if(currentHealth <= 0 && !isDead)
		{
			// Gaat ie dood
			Death ();
		}
		Debug.Log (this.name);
	}
	
	
	void Death ()
	{
		// Is op dit moment dood
		isDead = true;

		// Zet bewegen en schieten uit
		if (this.name == "Player") {
			playerMovement.enabled = false;
			playerShoot.enabled = false;
		} else if (this.name == "Enemy") {
			enemyAI.enabled = false;
		}

		// HIER MOET EEN RESPAWN SCHERM KOMEN, EN ALS ER OP RESPAWN WORDT GEKLIKT KRIJG JE DE ONDERSTAANDE REGEL
		playerSpawn.Respawn();
	}   

	public void SetHealth(int health){
		currentHealth = health;
		healthText.text = currentHealth.ToString() + "%";
		healthSlider.value = currentHealth;
	}
}