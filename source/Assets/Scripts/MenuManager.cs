using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public string CurrentMenu;		//Menu the player is in
	public string Name;				//Server name	

	//Button textures
	public Texture StartButton;
	public Texture JoinButton;
	public Texture HostButton;
	public Texture RefreshButton;
	public Texture ReturnButton;
	public Texture QuitButton;
	public Texture Background;

	void Start () {
		CurrentMenu = "Main";
		Audio.Instance.PlayMenuMusic();
	}
	
	void OnGUI() {
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),Background);

		if(CurrentMenu == "Main") {
			MainMenu ();
		}

		if(CurrentMenu == "Host") {
			HostMenu ();
		}

		if(CurrentMenu == "Server List") {
			ServerListMenu();
		}

	}


	void ChangeMenu(string menu) {
		CurrentMenu = menu;
	}


	void MainMenu() {

		//Button that goes to the next menu where players can host a match/server
		if(GUI.Button(new Rect(50,25,150,75), HostButton, GUIStyle.none)) {
			ChangeMenu("Host");
		}

		//Button that goes to the next menu where players can join a match/server
		if(GUI.Button(new Rect(50,105,150,75), JoinButton, GUIStyle.none)) {
			ChangeMenu("Server List");
			NetworkManager.Instance.RefreshServerList();			
		}

		//Button that quits the game
		if(GUI.Button (new Rect(50,185,150,75), QuitButton, GUIStyle.none)) {
			Application.Quit ();
		}
	}

	void HostMenu() {

		//Button that starts a new server
		if(GUI.Button(new Rect(50,25,150,75), StartButton, GUIStyle.none)) {
			NetworkManager.Instance.StartServer(Name, 2);

		}

		//Text field where players can enter there servername
		Name = GUI.TextField(new Rect(50,105,150,40), Name);

		//Return to main menu
		if(GUI.Button(new Rect(50,150,150,75), ReturnButton, GUIStyle.none)) {
			ChangeMenu("Main");
		}
	}

	void ServerListMenu() {

		//Refresh the list containing all servers that are online
		if(GUI.Button(new Rect(50,25,150,75), RefreshButton, GUIStyle.none)) {
			NetworkManager.Instance.RefreshServerList();
		}

		//return to main menu
		if(GUI.Button(new Rect(50,105,150,75), ReturnButton, GUIStyle.none)) {
			ChangeMenu("Main");
		}

		//if there are servers -> show button for every server, so players can connect to the server
		if(NetworkManager.Instance.hostdata != null) {
			for(int i = 0; i < NetworkManager.Instance.hostdata.Length; i++) {
				if(GUI.Button (new Rect(Screen.width/2, 65f + (30 * i), 300f, 30f), NetworkManager.Instance.hostdata[i].gameName)) {
					NetworkManager.Instance.ConnectToServer(NetworkManager.Instance.hostdata[i]);
					ChangeScene.Instance.ChangeSceneTo("Map01");
				}
			}
		}
	}

}//End of class