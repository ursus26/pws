using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	//Menu status
	public bool MenuOpen = false;

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
		MenuOpen = false;

		//get Components
		MovementScript = GetComponent<PlayerMovement>();
		ShootScript = GetComponentInChildren<PlayerShoot>();
	}
	
	// Update is called once per frame
	void Update() {
		if(Input.GetKeyDown (KeyCode.Escape)) {//If Esc key is pressed -> open or close menu
			MenuOpen = ChangeMenuState();
		}
	}


	bool ChangeMenuState() {
		if(MenuOpen == false) {//open menu and disable player actions
			DisablePlayerActions();
			return true;
		} else {//close the menu and enable player actions
			EnablePlayerActions();
			return false;
		}

	}


	void OnGUI() {

		if(MenuOpen == true) {//When menu is open draw these buttons

			GUI.BeginGroup(new Rect(((Screen.width / 2) - (GroupWidth / 2)), ((Screen.height / 2) - (GroupHeight / 2)), GroupWidth, GroupHeight));

			//Reseme button
			if(GUI.Button(new Rect(0,0, ButtonWidth, ButtonHeight),"Resume")){
				MenuOpen = false;
				EnablePlayerActions();
			}

			//Exit level button
			if(GUI.Button(new Rect(0,60, ButtonWidth, ButtonHeight),"Exit level")){
				Application.LoadLevel ("Menu");
			}

			GUI.EndGroup();
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