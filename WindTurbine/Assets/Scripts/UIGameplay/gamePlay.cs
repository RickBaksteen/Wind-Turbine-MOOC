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
		GameObject.FindGameObjectWithTag ("canvas").GetComponent<CanvasGroup> ().alpha = 1;
		GameObject.FindGameObjectWithTag ("canvas").GetComponent<CanvasGroup> ().interactable = true;

		GameObject.FindGameObjectWithTag ("canvasMenu").GetComponent<CanvasGroup> ().alpha = 0;
		GameObject.FindGameObjectWithTag ("canvasMenu").GetComponent<CanvasGroup> ().interactable = false;
	}

	public void pause(){
		Time.timeScale = 0;
	}

	public void accelerate(){

		if (Time.timeScale < 12) {
			Time.timeScale += 1;
		}
	}
}
