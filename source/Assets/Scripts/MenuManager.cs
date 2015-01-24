using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	public string CurrentMenu;
	public string Name;

	void Start () {
		CurrentMenu = "Main";
	}
	
	void OnGUI() {
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
		if(GUI.Button(new Rect(50,25,100,40), "Host")) {
			ChangeMenu("Host");
		}

		//Button that goes to the next menu where players can join a match/server
		if(GUI.Button(new Rect(50,65,100,40), "Join server")) {
			ChangeMenu("Server List");
			NetworkManager.Instance.RefreshServerList();


			
		}
	}

	void HostMenu() {

		//Button that starts a new server
		if(GUI.Button(new Rect(50,25,100,40), "Start")) {
			NetworkManager.Instance.StartServer(Name, 8);

		}

		//Text field where players can enter there servername
		Name = GUI.TextField(new Rect(50,65,100,40), Name);

		//Return to main menu
		if(GUI.Button(new Rect(50,105,100,40), "Return")) {
			ChangeMenu("Main");
		}
	}

	void ServerListMenu() {

		//Refresh the list containing all servers that are online
		if(GUI.Button(new Rect(50,65,100,40), "Refresh")) {
			NetworkManager.Instance.RefreshServerList();
		}

		//return to main menu
		if(GUI.Button(new Rect(50,105,100,40), "Return")) {
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