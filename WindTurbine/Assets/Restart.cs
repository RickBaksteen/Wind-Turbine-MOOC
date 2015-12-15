using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

    // Use this for restarting game
    public void restart()
    {
        Debug.Log("Button Clicked");
        Application.LoadLevel(CurrentLevel .currentLevel );
        Time.timeScale = 1;
    }
}
