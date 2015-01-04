function OnTriggerEnter(other : Collider){
	if (other.gameObject.tag="Wall"){
		Destroy(this.gameObject);
	}
}