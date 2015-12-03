using UnityEngine;
using System.Collections;

public class gamePlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play(){
		Time.timeScale = 1;
	}

	public void pause(){
		Time.timeScale = 0;
	}

	public void accelerate(){
		Time.timeScale++;
	}
}
