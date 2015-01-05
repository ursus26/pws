using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	//GameObject PlayButton = GameObject.Find("PlayButton");
	//GameObject ExitButton = GameObject.Find ("ExitButton");

	// Use this for initialization
	public string CurrentMenu;
	public string Name;

	void Start () {
		CurrentMenu = "Main";
	}
	
	// Update is called once per frame
	void Update () {

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
		if(GUI.Button(new Rect(50,25,100,40), "Host")) {
			ChangeMenu("Host");
		}
		if(GUI.Button(new Rect(50,65,100,40), "Join server")) {
			ChangeMenu("Server List");
		}
	}

	void HostMenu() {
		if(GUI.Button(new Rect(50,25,100,40), "Start")) {
			NetworkManager.Instance.StartServer(Name, 2);

		}
		Name = GUI.TextField(new Rect(50,65,100,40), Name);

		if(GUI.Button(new Rect(50,105,100,40), "Return")) {
			ChangeMenu("Main");
		}
	}

	void ServerListMenu() {

		if(GUI.Button(new Rect(50,65,100,40), "Refresh")) {
			MasterServer.RequestHostList("TDM");
		}

		if(GUI.Button(new Rect(50,105,100,40), "Return")) {
			ChangeMenu("Main");
		}


		GUILayout.BeginArea(new Rect(Screen.width/2,0,Screen.width/2,Screen.height), "Server list");

		foreach(HostData hd in MasterServer.PollHostList()) {

			GUILayout.BeginHorizontal();
			GUILayout.Label(hd.gameName);
			if(GUILayout.Button ("Connect")) {
				Network.Connect(hd);
			}
			GUILayout.EndHorizontal();

		}
		GUILayout.EndArea();

	}
}
