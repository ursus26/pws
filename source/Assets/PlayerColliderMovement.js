function OnTriggerEnter2D(obj : Collider2D) {
		var name = obj.gameObject.name;
		var tag = obj.gameObject.tag;
		

		if (tag == "Wall"){
			transform.Translate(Vector3.down * 1f * Time.deltaTime);
		}
	}