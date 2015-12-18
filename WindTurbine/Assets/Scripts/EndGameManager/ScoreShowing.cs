using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreShowing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.GetChild (0).GetComponent<Text> ().text = "Score: " + ScoreManager.score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
