using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class acceleration : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.GetChild (0).GetComponent<Text> ().text = "x " + Time.timeScale;
	}
}
