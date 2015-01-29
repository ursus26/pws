using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	//Menu status
	public bool GameMenuOpen = false;

	//Button variables
	private int ButtonWidth = 250;
	private int ButtonHeight = 50;
	private int GroupWidth = 250;
	private int GroupHeight = 200;

	//Components
	private PlayerMovement MovementScript;
	private PlayerShoot ShootScript;


	// Use this for initialization
	void Start () {
		GameMenuOpen = false;

		//get Components
		MovementScript = GetComponent<PlayerMovement>();
		ShootScript = GetComponentInChildren<PlayerShoot>();
	}
	
	// Update is called once per frame
	void Update() {
		if(Input.GetKeyDown (KeyCode.Escape)) {//If Esc key is pressed -> open or close menu
			GameMenuOpen = ChangeMenuState();
		}
	}


	void OnGUI() {

		if(GameMenuOpen == true) {//When menu is open draw these buttons

			GUI.BeginGroup(new Rect(((Screen.width / 2) - (GroupWidth / 2)), ((Screen.height / 2) - (GroupHeight / 2)), GroupWidth, GroupHeight));

			//Reseme button
			if(GUI.Button(new Rect(0,0, ButtonWidth, ButtonHeight),"Resume")){
				GameMenuOpen = false;
				EnablePlayerActions();
			}

			//Exit level button
			if(GUI.Button(new Rect(0,60, ButtonWidth, ButtonHeight),"Exit level")){
				Network.Disconnect();
			}

			GUI.EndGroup();
		}
	}


	bool ChangeMenuState() {
		if(GameMenuOpen == false) {//open menu and disable player actions
			DisablePlayerActions();
			return true;
		} else {//close the menu and enable player actions
			EnablePlayerActions();
			return false;
		}
		
	}


	//Disable all player actions like movement and shooting
	void DisablePlayerActions() {
		MovementScript.enabled = false;
		ShootScript.enabled = false;
	}


	//Enable all player actions like movement and shooting
	void EnablePlayerActions() {
		MovementScript.enabled = true;
		ShootScript.enabled = true;
	}

}//End of class
