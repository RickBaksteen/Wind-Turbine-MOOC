using UnityEngine;
using System.Collections;

public class OpenMenu : MonoBehaviour {

	public GameObject p;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void open() {

		p.SetActive (true);
		GameObject.FindGameObjectWithTag ("canvas").GetComponent<CanvasGroup> ().alpha = 0;
		GameObject.FindGameObjectWithTag ("canvas").GetComponent<CanvasGroup> ().interactable = false;
		
		GameObject.FindGameObjectWithTag ("canvasMenu").GetComponent<CanvasGroup> ().alpha = 1;
		GameObject.FindGameObjectWithTag ("canvasMenu").GetComponent<CanvasGroup> ().interactable = true;
		GameObject.FindGameObjectWithTag ("canvasMenu").GetComponent<CanvasGroup> ().blocksRaycasts = true;

		GridInfo.showInfo = false;
	}
}
