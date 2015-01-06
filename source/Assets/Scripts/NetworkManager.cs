using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {

	public static NetworkManager Instance;
	string UniqueGameName = "KKC_PWS_2015_Team_Death_Match";
	public string PlayerName;
	public string MatchName;
	//public List<Player> Playerlist = new List<Player>();


	//Server list variables
	float RefreshRequestLength = 3f;
	public HostData[] hostdata;


	// Use this for initialization
	void Start () {
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}


	public void StartServer(string ServerName, int MaxPlayerCount) {
		Network.InitializeServer(MaxPlayerCount, 25002, false);
		MasterServer.RegisterHost(UniqueGameName, ServerName, "PWS server");
	}


	void OnMasterServerEvent(MasterServerEvent masterServerEvent) {
		if(masterServerEvent == MasterServerEvent.RegistrationSucceeded) {
			Debug.Log ("Server has been registered");
		}
	}

	public IEnumerator RefreshHostList() {
		Debug.Log ("Refreshing...");

		MasterServer.RequestHostList(UniqueGameName);
		float timeEnd = Time.time + RefreshRequestLength;

		while(Time.time < timeEnd) {
			hostdata = MasterServer.PollHostList();
			yield return new WaitForEndOfFrame();
		}

		if(hostdata == null || hostdata.Length == 0) {
			Debug.Log ("No servers has been found");
		}
	}


	public void StartRefreshCoRoutine() {
		StartCoroutine("RefreshHostList");
	}

	public void ConnectToServer(HostData hostdata) {
		Network.Connect(hostdata);
		Debug.Log ("Connect to server");
	}


	void OnServerInitialized() {
		ChangeScene.Instance.ChangeSceneTo("Map01");
		Network.Instantiate(Resources.Load ("Prefabs/Player1"), new Vector3(0f,0f,0f), Quaternion.identity, 0);

	}



}//End of class