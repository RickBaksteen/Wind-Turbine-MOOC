using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

    // Use this for restarting game
    public void restart()
    {
		GameEnd.clearLevelElement ();
		Debug.Log("Button Clicked");
        Application.LoadLevel(CurrentLevel .currentLevel );
    }
}
