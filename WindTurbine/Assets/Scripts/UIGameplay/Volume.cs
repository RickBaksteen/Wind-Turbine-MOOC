using UnityEngine;
using System.Collections;

public class Volume : MonoBehaviour {

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void volumeUp(){

		AudioListener.volume = 0f ;

	}

	public void volumenDown(){



	}

	public void mute(){

		AudioListener.volume = 0f;

	}

	public void unmute(){

		AudioListener.volume = 1f;

	}
}
