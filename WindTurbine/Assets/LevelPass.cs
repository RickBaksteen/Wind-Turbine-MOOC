using UnityEngine;
using System.Collections;

public class LevelPass : MonoBehaviour {

    public void restart()
    {
        
        Debug.Log("Button Clicked");
        if (CurrentLevel.currentLevel < 3)
        {
            CurrentLevel.currentLevel += 1;
            Application.LoadLevel(CurrentLevel.currentLevel);
            Time.timeScale = 1;
        }
        else
        {
            Application.LoadLevel("Begin");
            Time.timeScale = 1;
        }
    }
}
