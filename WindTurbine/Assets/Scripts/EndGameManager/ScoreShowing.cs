using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreShowing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName == "Fail") {
			transform.GetChild (0).GetComponent<Text> ().text = "Score: 0"; // + ScoreManager.score;
		} else {
			transform.GetChild (0).GetComponent<Text> ().text = "Score: " + ScoreManager.score;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
