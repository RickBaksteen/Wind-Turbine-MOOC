using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class OutputManager : MonoBehaviour {

	private int output = 0;

	// Use this for initialization
	void Start () {
		output = 0;
	}
	
	// Update is called once per frame
	void Update () {

		try {

			output = GameObject.FindGameObjectWithTag ("turbine").transform.GetComponent<TurbineInfo> ().output;
			gameObject.transform.GetChild(0).GetComponent<Text>().text = "   Output: " + output + " kWh";
			
		}       
		catch (NullReferenceException ex) {
			
		};
	}
}
