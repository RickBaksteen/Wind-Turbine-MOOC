using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void mainMenu()
    {
        GameEnd.clearLevelElement();
        Debug.Log("Button Clicked");
        Application.LoadLevel(0);
    }
}
