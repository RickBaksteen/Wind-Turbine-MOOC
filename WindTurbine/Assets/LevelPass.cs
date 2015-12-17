using UnityEngine;
using System.Collections;

public class LevelPass : MonoBehaviour {

    public void restart()
    {
        
        Debug.Log("Button Clicked");
        if (CurrentLevel.currentLevel < 4)
        {
            CurrentLevel.currentLevel += 1;
            Application.LoadLevel(CurrentLevel.currentLevel);
            Time.timeScale = 1;

			KilledDrops.killedDrops = 0;
			WaterCountManager.waterCount = 0;
			GameObject.FindGameObjectWithTag("createManager").GetComponent<CreateManager>().turbineNum = 0;
			MoneyManager.money = 1000;
        }
        else
        {
            Application.LoadLevel("Begin");
            Time.timeScale = 1;

			KilledDrops.killedDrops = 0;
			WaterCountManager.waterCount = 0;
			GameObject.FindGameObjectWithTag("createManager").GetComponent<CreateManager>().turbineNum = 0;
			MoneyManager.money = 1000;
        }
    }
}
