using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {

	public static NetworkManager Instance;
	string UniqueGameName = "KKC_PWS_2015_Team_Death_Match";
	public string PlayerName;
	public string MatchName;

	private GameObject LocalPlayer;

	public GameObject PlayerPrefab;

	private Camera originalCamera;

	//Server list variables
	float RefreshRequestLength = 3f;
	public HostData[] hostdata;


	void Awake() {
		if(Instance) {
			DestroyImmediate(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
	}

	public void StartServer(string ServerName, int MaxPlayerCount) {
		Network.InitializeServer(MaxPlayerCount, 23465, true);
		MasterServer.RegisterHost(UniqueGameName, ServerName, "PWS server");
	}

	private IEnumerator RefreshHostList() {
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

	public void RefreshServerList() {
		StartCoroutine("RefreshHostList");
	}

	public void ConnectToServer(HostData hostdata) {
		Network.Connect(hostdata);
		Debug.Log ("Connect to server");
	}

	private void SpawnPlayer() {
		originalCamera = GameObject.Find("MainCamera").camera;
		LocalPlayer = (GameObject)Network.Instantiate(PlayerPrefab, new Vector3(0f,0f,-1f), Quaternion.identity, 1);
		LocalPlayer.GetComponentInChildren<PlayerShoot>().enabled = true;	
		//LocalPlayer.GetComponent<PlayerShoot>().enabled = true;
		LocalPlayer.GetComponent<Menu>().enabled = true;
		LocalPlayer.GetComponent<PlayerMovement>().enabled = true;
		LocalPlayer.GetComponent<PlayerMovement>().setCamera(originalCamera);

		originalCamera.GetComponent<CameraMovement>().setCameraTarget(LocalPlayer);

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