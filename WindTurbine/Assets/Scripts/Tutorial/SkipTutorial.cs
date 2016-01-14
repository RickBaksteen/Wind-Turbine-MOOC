using UnityEngine;
using System.Collections;

public class SkipTutorial : MonoBehaviour {
    public GameObject t;

    private GameObject[] objs;
    private GameObject obj;
    public CameraMoving cam;


    // Use this for initialization
    public void Click () {
        t.SetActive(false);
        Time.timeScale = 1;
        cam.speed = 2;
        cam.zoomSpeed = 5;
		gameObject.SetActive (false);
    }
	
    void Start() { }
  
}
