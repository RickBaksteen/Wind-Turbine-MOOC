using UnityEngine;
using System.Collections;

public class OpenMenu : MonoBehaviour {

	public GameObject p;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void open() {

		p.SetActive (true);
	}
}
