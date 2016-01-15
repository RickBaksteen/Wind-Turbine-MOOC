using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Question : MonoBehaviour {
    public GameObject p;

	public bool clicked;
	//public GameObject step0;

	// Use this for initialization
	public void Click () {

		clicked = true;

		p.SetActive(true);

		if (Application.loadedLevelName == "Level1_1") {
		
			p.transform.GetChild(0).gameObject.SetActive(true);
			p.transform.GetChild(1).gameObject.SetActive(false);
			p.transform.GetChild(2).gameObject.SetActive(false);
			p.transform.GetChild(3).gameObject.SetActive(false);
			p.transform.GetChild(4).gameObject.SetActive(false);
			p.transform.GetChild(5).gameObject.SetActive(false);
		
		}

		else if (Application.loadedLevelName == "Level2_1") {
			
			p.transform.GetChild(0).gameObject.SetActive(true);
			p.transform.GetChild(1).gameObject.SetActive(false);
			p.transform.GetChild(2).gameObject.SetActive(false);
			p.transform.GetChild(3).gameObject.SetActive(false);
			p.transform.GetChild(4).gameObject.SetActive(false);
			
		}

		else if(Application.loadedLevelName == "Level3_1")
		{
			p.transform.GetChild(0).gameObject.SetActive(true);
			p.transform.GetChild(1).gameObject.SetActive(false);
			p.transform.GetChild(2).gameObject.SetActive(false);
			//p.transform.GetChild(3).gameObject.SetActive(false);
		}

		else if(Application.loadedLevelName == "Level4_1")
		{
			p.transform.GetChild(0).gameObject.SetActive(true);
			p.transform.GetChild(1).gameObject.SetActive(false);
			p.transform.GetChild(2).gameObject.SetActive(false);
			//p.transform.GetChild(3).gameObject.SetActive(false);
		}



		//step0.SetActive (true);
		Time.timeScale = 0;

		//Debug.Log ("Tutorial Begin");

		GridInfo.showInfo = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (clicked) {
		
			gameObject.GetComponent<Button>().interactable = false;
		
		}

		else{
			
			gameObject.GetComponent<Button>().interactable = true;
			
		}

	}

	void Start(){


		clicked = true;

	}
}
