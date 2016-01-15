using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkipTutorial : MonoBehaviour {
    public GameObject t;

    private GameObject[] objs;
    private GameObject obj;
    public CameraMoving cam;


    // Use this for initialization
    public void Click () {
        
		GameObject.FindGameObjectWithTag ("questionBtn").GetComponent<Question> ().clicked = false;
		t.SetActive(false);
        Time.timeScale = 1;
        cam.speed = 2;
        cam.zoomSpeed = 5;

		//transform.parent.parent.gameObject.SetActive (false);
		//gameObject.SetActive (false);

		GridInfo.showInfo = true;

		
    }
	
    void Start() { }
  
}
