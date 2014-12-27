function OnTriggerEnter2D(obj : Collider2D) {
		var name = obj.gameObject.name;
		var tag = obj.gameObject.tag;
		

		if (tag == "Wall"){
			Destroy (this.gameObject);
		}
		
		if (tag == "Player" | tag == "Enemy"){
			Destroy (this.gameObject);
		}
	}