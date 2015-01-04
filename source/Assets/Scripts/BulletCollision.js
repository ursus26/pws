function OnTriggerEnter2D(obj : Collider2D) {
		var player = GameObject.Find("Player");
		var playerHealth = player.GetComponent("PlayerHealth");
		
		
		var name = obj.gameObject.transform.parent.name;
		var tag = obj.gameObject.tag;
		

		if (tag == "Wall"){
			Destroy (this.gameObject);
			playerHealth.TakeDamage(5);
		}
		
		if (name == "Player" || name == "Enemy"){
			Destroy (this.gameObject);
		    obj.transform.parent.GetComponent("PlayerHealth").TakeDamage(5);
		}
	}