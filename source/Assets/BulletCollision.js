function OnTriggerEnter2D(obj : Collider2D) {
		var name = obj.gameObject.name;
		var tag = obj.gameObject.tag;
		

		if (name == "GameObject"){
			Destroy (this.gameObject);
		}
	}