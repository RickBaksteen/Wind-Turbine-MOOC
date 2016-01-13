using UnityEngine;
using System.Collections;

public class GameEnd : MonoBehaviour {

    public int allDrops = 30;
   // public int killedDrops = 0;
    

	// Use this for initialization
	void Start () {

		if (Application.loadedLevelName == "Level3_2" || Application.loadedLevelName == "Level4_2") {
		
			allDrops = 40;

		} else {
		
			allDrops = 30;
		
		}

	}
	
	// Update is called once per frame
	void Update () {
	
        if (WaterCountManager.waterCount == 10)
        {
            Application.LoadLevel("Fail");
        }
       else if ((KilledDrops. killedDrops + WaterCountManager.waterCount ) == allDrops )
        {
			KilledDrops.killedDrops = 0;
            Application.LoadLevel("Win");
        }
       
    }

	public static void clearLevelElement()
	{
		KilledDrops.killedDrops = 0;
		WaterCountManager.waterCount = 0;
		MoneyManager.money = 1000;
		CreateManager.turbineNum = 0;
		WindTurbineBtnInfo.anyButtonCreate = false;
		
		Time.timeScale = 1;
	}
}
