using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {

	public static NetworkManager Instance;
	string UniqueGameName = "KKC_PWS_2015_Team_Death_Match";
	public string PlayerName;
	public string MatchName;
	//public List<Player> Playerlist = new List<Player>();


	public GameObject PlayerPrefab;

	//Server list variables
	float RefreshRequestLength = 3f;
	public HostData[] hostdata;


	// Use this for initialization
	void Start () {
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}


	public void StartServer(string ServerName, int MaxPlayerCount) {
		Network.InitializeServer(MaxPlayerCount, 23465, true);
		MasterServer.RegisterHost(UniqueGameName, ServerName, "PWS server");
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


	private void SpawnPlayer() {
		Network.Instantiate(PlayerPrefab, new Vector3(0f,0f,-1f), Quaternion.identity, 1);
		Debug.Log ("Player spawned");
	}


	void OnLevelWasLoaded(){
		if(Network.isServer)
			SpawnPlayer ();
	}


	void OnServerInitialized() {
		ChangeScene.Instance.ChangeSceneTo("Map01");
	}

	void OnMasterServerEvent(MasterServerEvent masterServerEvent) {
		if(masterServerEvent == MasterServerEvent.RegistrationSucceeded) {
			Debug.Log ("Server has been registered");
		}
	}

	void OnConnectedToServer() {
		SpawnPlayer ();
	}

	void OnDisconnectFromServer() {

	}


	void OnFailedToConnect() {

		ChangeScene.Instance.ChangeSceneTo("MainMenu");
	}

	/*
	void OnNetworkInstantiate() {

	}

*/
	void OnPlayerConnected() {

	}

	void OnPlayerDisconnected(NetworkPlayer player) {
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
		Destroy(PlayerPrefab);
	}

	void OnApplicationQuit() {
		if(Network.isServer) {
			Network.Disconnect(200);
			MasterServer.UnregisterHost();
		}

		if(Network.isClient) {
			Network.Disconnect(200);
		}
	}

	/*
	void OnSerializeNetworkView() {

	}
*/



}//End of class