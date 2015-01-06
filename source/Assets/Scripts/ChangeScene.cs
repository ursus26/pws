using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public static ChangeScene Instance;

	void Start () {
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public void ChangeSceneTo(string SceneName) {
		Application.LoadLevel(SceneName);
	}

	public void ExitGame() {
		Application.Quit();
	}
}