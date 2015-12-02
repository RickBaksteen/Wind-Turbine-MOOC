using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OutputManager : MonoBehaviour {

	private int output;

	// Use this for initialization
	void Start () {
		output = 0;
	}
	
	// Update is called once per frame
	void Update () {
		output = GameObject.FindGameObjectWithTag ("turbine").transform.GetComponent<TurbineInfo> ().output;
		gameObject.transform.GetChild(0).GetComponent<Text>().text = "   Output: " + output + " km/s";
	}
}
