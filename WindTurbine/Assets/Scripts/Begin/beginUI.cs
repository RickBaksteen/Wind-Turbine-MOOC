using UnityEngine;
using System.Collections;

public class beginUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadChapter1_1(){
		CurrentLevel.currentLevel = 1;
		GameEnd.clearLevelElement ();
		Application.LoadLevel ("Level1");
	}


	public void loadChapter1_2(){
		CurrentLevel.currentLevel = 2;
		GameEnd.clearLevelElement ();
		Application.LoadLevel ("Level2");
	}

	public void loadChapter1_3(){
		CurrentLevel.currentLevel = 3;
		GameEnd.clearLevelElement ();
		Application.LoadLevel ("Level3");
	}

	public void loadChapter1_4(){
		CurrentLevel.currentLevel = 4;
		GameEnd.clearLevelElement ();
		Application.LoadLevel ("Level4");
	}

	public void loadChapter1_5(){
		CurrentLevel.currentLevel = 5;
		GameEnd.clearLevelElement ();
		Application.LoadLevel ("Level5");
	}

}
