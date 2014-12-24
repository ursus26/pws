using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public void ChangeSceneTo(string SceneName) {
		Application.LoadLevel(SceneName);
	}

	public void ExitGame() {
		Application.Quit();
	}
}
