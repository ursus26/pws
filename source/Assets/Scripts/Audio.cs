using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

	public static Audio Instance;

	public AudioClip GunShot;
	public AudioClip GameMusic;
	public AudioClip MenuMusic;


	void Awake() {
		//Only accepts 1 instance of this class, other instances will be deleted
		if(Instance) {
			DestroyImmediate(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);	
			Instance = this;
		}
	}
	
	public void PlayGunShot() {
		audio.PlayOneShot(GunShot);
	}

	public void PlayGameMusic() {
		audio.PlayOneShot(GameMusic);
	}

	public void PlayMenuMusic() {
		audio.PlayOneShot(MenuMusic);
	}

	public void StopMusic() {
		audio.Stop();
	}

}
