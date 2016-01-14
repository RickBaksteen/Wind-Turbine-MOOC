using UnityEngine;
using System.Collections;

public class gamePlay : MonoBehaviour {

	public bool volumePanelOpen;

	// Use this for initialization
	void Start () {
		volumePanelOpen = false;

		GameObject.Find ("Utility").GetComponent<CanvasGroup> ().alpha = 0f;
		GameObject.Find ("Utility").GetComponent<CanvasGroup> ().interactable = false;
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
		GameObject.FindGameObjectWithTag ("canvasMenu").GetComponent<CanvasGroup> ().blocksRaycasts = false;

		GridInfo.showInfo = true;
	}

	public void pause(){
		Time.timeScale = 0;
	}

	public void accelerate(){

		if (Time.timeScale < 12) {
			Time.timeScale += 1;
		}
	}

	public void volumeControl(){

		volumePanelOpen = !volumePanelOpen;


		if (volumePanelOpen) {
		
			GameObject.Find ("Utility").GetComponent<CanvasGroup> ().alpha = 1f;
			GameObject.Find ("Utility").GetComponent<CanvasGroup> ().interactable = true;
		
		} else {
		
			GameObject.Find ("Utility").GetComponent<CanvasGroup> ().alpha = 0f;
			GameObject.Find ("Utility").GetComponent<CanvasGroup> ().interactable = false;

		}

	}
}
