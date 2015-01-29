using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public static ChangeScene Instance;

	void Awake() {

		//Only accepts 1 instance of this class, other instances will be deleted
		if(Instance) {
			DestroyImmediate(gameObject);
		} else {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void ChangeSceneTo(string SceneName) {	//Change the scene
		Audio.Instance.StopMusic();
		Application.LoadLevel(SceneName);
	}

	public void ExitGame() {	//Close the game
		Application.Quit();
	}
}