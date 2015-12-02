using UnityEngine;
using System.Collections;
using System;

public class TurbineInfo : MonoBehaviour {

	public string[] directions = {"N", "NE", "E", "SE", "S", "SW", "W", "NW"};
	public int directionIndex = 0;
	public string direction;
	public int output = 140;
	public int maxOutput = 140;


	// Use this for initialization
	void Start () {
		direction = directions [directionIndex];
	}
	
	// Update is called once per frame
	void Update () {
		CalculateOutput ();
	}

	public void CalculateOutput(){
		int wind = GameObject.FindGameObjectWithTag ("wind").transform.GetComponent<WindManager>().windIndex;
		int angle = Math.Abs (wind - directionIndex) % 4;

		if (Math.Abs (wind - directionIndex) == 4) {
			angle = 4;
		}

		output = maxOutput * (4 - angle)/4;

	}

	void OnMouseClick()
	{
		Debug.Log ("Turbine Click");
	}
}
