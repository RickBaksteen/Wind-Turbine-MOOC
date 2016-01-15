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
		Application.LoadLevel ("Level1_1");
	}


	public void loadChapter1_2(){
		CurrentLevel.currentLevel = 2;
		GameEnd.clearLevelElement ();
		Application.LoadLevel ("Level1_2");
	}

	public void loadChapter2_1(){
		CurrentLevel.currentLevel = 3;
		GameEnd.clearLevelElement ();
		Application.LoadLevel ("Level2_1");
	}

	public void loadChapter2_2(){
		CurrentLevel.currentLevel = 4;
		GameEnd.clearLevelElement ();
		Application.LoadLevel ("Level2_2");
	}

	public void loadChapter3_1(){
		CurrentLevel.currentLevel = 5;
		GameEnd.clearLevelElement ();
		Application.LoadLevel ("Level3_1");
	}

	public void loadChapter3_2(){
		CurrentLevel.currentLevel = 6;
		GameEnd.clearLevelElement ();
		Application.LoadLevel ("Level3_2");
	}

	public void loadChapter4_1(){
		CurrentLevel.currentLevel = 7;
		GameEnd.clearLevelElement ();
		Application.LoadLevel ("Level4_1");
	}

	public void loadChapter4_2(){
		CurrentLevel.currentLevel = 8;
		GameEnd.clearLevelElement ();
		Application.LoadLevel ("Level4_2");
	}

}
