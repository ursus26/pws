using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {

	public static NetworkManager Instance;				//Instance of this class
	string UniqueGameName = "KKC_PWS_2015_Team_Death_Match";	//Unique name

	private GameObject LocalPlayer;					//Local player object that the user controls
	public GameObject PlayerPrefab;					//Prefab of the player
	private Camera originalCamera;					//Main camera in game

	//Server list variables
	float RefreshRequestLength = 3f;				//Time it's searching for servers
	public HostData[] hostdata;					//Data of the found hosts


	void Awake() {
		//Only accepts 1 instance of this class, other instances will be deleted
		if(Instance) {
			DestroyImmediate(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
	}

	public void StartServer(string ServerName, int MaxPlayerCount) {
		Network.InitializeServer(MaxPlayerCount, 23465, true);			//Init a server
		MasterServer.RegisterHost(UniqueGameName, ServerName, "PWS server");	//Register the room of the host
	}

	private IEnumerator RefreshHostList() {
		MasterServer.RequestHostList(UniqueGameName);		//Get hostlist of the unique game name
		float timeEnd = Time.time + RefreshRequestLength;	//set time it will be searching for servers

		while(Time.time < timeEnd) {				
			hostdata = MasterServer.PollHostList();
			yield return new WaitForEndOfFrame();		
		}

		if(hostdata == null || hostdata.Length == 0) {		//After the search, if there are no servers
			Debug.Log ("No servers has been found");
		}
	}

	public void RefreshServerList() {
		StartCoroutine("RefreshHostList");
	}

	public void ConnectToServer(HostData hostdata) {	//Connect to a server
		Network.Connect(hostdata);
	}

	private void SpawnPlayer() {
		//Find main camera
		originalCamera = GameObject.Find("MainCamera").camera;
		
		//Create the player that the user controls
		LocalPlayer = (GameObject)Network.Instantiate(PlayerPrefab, 
			new Vector3(0f,0f,-1f), Quaternion.identity, 1);
		
		//Enable Player scripts so the user is the only person controlling the local player
		LocalPlayer.GetComponentInChildren<PlayerShoot>().enabled = true;
		LocalPlayer.GetComponent<Menu>().enabled = true;
		LocalPlayer.GetComponent<PlayerMovement>().enabled = true;
		
		//Set camera to follow local player
		LocalPlayer.GetComponent<PlayerMovement>().setCamera(originalCamera);
		originalCamera.GetComponent<CameraMovement>().setCameraTarget(LocalPlayer);
	}
	
	public void DestroyNetworkObject(GameObject gameObject) {
		
		if(gameObject != null) {
			Network.RemoveRPCs(gameObject.networkView.viewID);	//Remove gameobject from network buffer
 			Network.Destroy(gameObject);						//Destroys gameobject from network
		}
	}
	
	void OnLevelWasLoaded(){
		if(Network.isServer)
			SpawnPlayer ();
	}


	void OnServerInitialized() {
		ChangeScene.Instance.ChangeSceneTo("Map01");	//when server has been initialized -> change the scene
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
		ChangeScene.Instance.ChangeSceneTo("MainMenu");
	}


	void OnFailedToConnect() {

		ChangeScene.Instance.ChangeSceneTo("MainMenu");
	}

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

}//End of class
