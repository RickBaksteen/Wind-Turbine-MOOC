using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

    // Use this for restarting game
    public void restart()
    {
        Debug.Log("Button Clicked");
        Application.LoadLevel(CurrentLevel .currentLevel );
        Time.timeScale = 1;

		KilledDrops.killedDrops = 0;
		WaterCountManager.waterCount = 0;
		GameObject.FindGameObjectWithTag("createManager").GetComponent<CreateManager>().turbineNum = 0;
    }
}
