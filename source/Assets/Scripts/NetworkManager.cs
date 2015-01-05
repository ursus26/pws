using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {

	public string PlayerName;
	public string MatchName;
	public static NetworkManager Instance;
	public List<Player> Playerlist = new List<Player>();

	// Use this for initialization
	void Start () {
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartServer(string ServerName, int MaxPlayerCount) {
		Network.InitializeSecurity();
		Network.InitializeServer(MaxPlayerCount, 16920, true);
		MasterServer.RegisterHost("TDM", ServerName);
		Debug.Log ("Started server");
	}
}


[System.Serializable]
public class Player {
	public string PlayerName;
}