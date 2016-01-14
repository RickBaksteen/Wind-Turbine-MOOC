using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

    private GameObject[] objs;
    private GameObject obj;
    public CameraMoving cam;

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
        //GameObject objs[] = GameObject
        /* objs = GameObject.FindGameObjectsWithTag("canvas");
         foreach (GameObject obj in objs)
         {
             obj.SetActive(false);
         }
         Step0.SetActive(true);*/
        cam.speed = 0;
        cam.zoomSpeed = 0;

		GridInfo.showInfo = false;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
