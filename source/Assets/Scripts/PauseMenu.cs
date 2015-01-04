﻿using UnityEngine;
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
	private PlayerMovement PM;
	private PlayerShoot PS;

	// Use this for initialization
	void Start () {
		MenuOpen = false;

		//get Components
		PM = GetComponent<PlayerMovement>();
		PS = GetComponentInChildren<PlayerShoot>();
	}
	
	// Update is called once per frame
	void Update() {
		if(Input.GetKeyDown (KeyCode.Escape)) {//If Esc key is pressed -> open or close menu
			MenuOpen = ChangeMenuState();
		}
	}


	bool ChangeMenuState() {
		if(MenuOpen == false) {//open menu and disable player actions
			PM.setLockMovementTrue();
			PS.setLockActionTrue();
			return true;
		} else {//close the menu and enable player actions
			PM.setLockMovementFalse();
			PS.setLockActionFalse();
			return false;
		}

	}


	void OnGUI() {

		if(MenuOpen == true) {//When menu is open draw these buttons

			GUI.BeginGroup(new Rect(((Screen.width / 2) - (GroupWidth / 2)), ((Screen.height / 2) - (GroupHeight / 2)), GroupWidth, GroupHeight));
			if(GUI.Button(new Rect(0,0, ButtonWidth, ButtonHeight),"Resume")){//Reseme button
				MenuOpen = false;
				PM.setLockMovementFalse();
				PS.setLockActionFalse();
			}

			if(GUI.Button(new Rect(0,60, ButtonWidth, ButtonHeight),"Exit level")){//Exit level button
				Application.LoadLevel ("Menu");
			}
			GUI.EndGroup();
		}

	}

}//End of class