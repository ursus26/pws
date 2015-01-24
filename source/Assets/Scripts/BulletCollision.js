



function OnTriggerEnter2D(obj : Collider2D) {

		var cs = GameObject.Find("Player1");
		//var playerHealth = cs.GetComponent("PlayerHealth");
		//var playerSpawn = cs.GetComponent("PlayerSpawn");

	
		
		var tag = obj.gameObject.tag;
		

		if (tag == "Wall"){
			Network.Destroy(GetComponent(NetworkView).id);
			//playerHealth.TakeDamage(5);
		}
		

		if (tag == "Player" || tag == "Enemy"){
			Network.Destroy(GetComponent(NetworkView).id);
			
			//Destroy (this.gameObject);
			//obj.playerHealth.TakeDamage();
		}
		
		/* if (tag == "Player" | tag == "Enemy"){
			Destroy (this.gameObject);
		} */

	}