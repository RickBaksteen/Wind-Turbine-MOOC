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
		Application.LoadLevel ("Level1");
        CurrentLevel.currentLevel = 1;

		KilledDrops.killedDrops = 0;
		WaterCountManager.waterCount = 0;
	}


	public void loadChapter1_2(){
		Application.LoadLevel ("Level2");
        CurrentLevel.currentLevel = 2;
		KilledDrops.killedDrops = 0;
		WaterCountManager.waterCount = 0;
	}

	public void loadChapter1_3(){
		Application.LoadLevel ("Level3");
        CurrentLevel.currentLevel = 3;
		KilledDrops.killedDrops = 0;
		WaterCountManager.waterCount = 0;
	}

	public void loadChapter1_4(){
		Application.LoadLevel ("Level4");
		CurrentLevel.currentLevel = 4;
		KilledDrops.killedDrops = 0;
		WaterCountManager.waterCount = 0;
	}


}
