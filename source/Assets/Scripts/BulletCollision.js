function OnTriggerEnter2D(obj : Collider2D) {
		var cs = GameObject.Find("Player");
		var playerHealth = cs.GetComponent("PlayerHealth");
		var playerSpawn = cs.GetComponent("PlayerSpawn");
		
		var name = obj.gameObject.name;
		var tag = obj.gameObject.tag;
		

		if (tag == "Wall"){
			Destroy (this.gameObject);
			playerHealth.TakeDamage(5);
		}
		
		if (tag == "Player" || tag == "Enemy"){
			Destroy (this.gameObject);
			obj.playerHealth.TakeDamage();
		}
	}