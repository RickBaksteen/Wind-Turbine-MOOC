using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Volume : MonoBehaviour {

	public static float value;

	// Use this for initialization
	void Start () {

		value = 1f;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (AudioListener.volume == 0) {
		
			GameObject.Find ("Mute").GetComponent<Button> ().interactable = false;
			//GameObject.Find ("UnMute").GetComponent<Button> ().interactable = true;
		
		} else {
		
			GameObject.Find ("Mute").GetComponent<Button> ().interactable = true;
			//GameObject.Find ("UnMute").GetComponent<Button> ().interactable = false;
		
		}

	}

	public void volumeUp(){

		value += 0.2f;
		value = Math.Min (value, 1f);
		AudioListener.volume = value;

	}

	public void volumenDown(){

		value -= 0.2f;
		value = Math.Max (value, 0f);
		AudioListener.volume = value;

	}

	public void mute(){

		AudioListener.volume = 0f;

	}

	public void unmute(){

		AudioListener.volume = value;

	}
}
