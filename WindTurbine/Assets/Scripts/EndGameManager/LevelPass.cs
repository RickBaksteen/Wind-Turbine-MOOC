using UnityEngine;
using System.Collections;

public class LevelPass : MonoBehaviour {

    public void restart()
    {
        
        Debug.Log("Button Clicked");
        if (CurrentLevel.currentLevel < 8)
        {
			GameEnd.clearLevelElement();
			CurrentLevel.currentLevel += 1;
            Application.LoadLevel(CurrentLevel.currentLevel);
        }
        else
        {
			GameEnd.clearLevelElement();
			Application.LoadLevel("Begin");
			
        }
    }
}
