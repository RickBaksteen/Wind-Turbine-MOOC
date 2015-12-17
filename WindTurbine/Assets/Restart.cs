using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

    // Use this for restarting game
    public void restart()
    {
        
		KilledDrops.killedDrops = 0;
		WaterCountManager.waterCount = 0;
		MoneyManager.money = 1000;

		Debug.Log("Button Clicked");
        Application.LoadLevel(CurrentLevel .currentLevel );
        Time.timeScale = 1;
		GameObject.FindGameObjectWithTag("createManager").GetComponent<CreateManager>().turbineNum = 0;

    }
}
