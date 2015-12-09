using UnityEngine;
using System.Collections;
using System;

public class TurbineInfo : InfoItem
{
    public string[] directions = { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };
    public int directionIndex = 0;
    public string direction;
	public int baseOutput = 100;
	public int originalOutput = 0;
	public int output = 0;
    public int maxOutput = 140;
	public int elevation;
	public float powerLoss;

    void Start()
    {
        direction = directions[directionIndex];
    }

    void Update()
    {
        //CalculateOutput();
		powerLoss = gameObject.transform.GetChild (1).GetComponent<powerLineInfo> ().loss;
		output = (int) (originalOutput * powerLoss);
    }

    public void CalculateOutput(int elevation)
    {
//        //int wind = GameObject.FindGameObjectWithTag("wind").transform.GetComponent<WindManager>().windIndex;
//		int wind = 0;
//		int angle = Math.Abs(wind - directionIndex) % 4;
//
//        if (Math.Abs(wind - directionIndex) == 4)
//        {
//            angle = 4;
//        }
//        output = maxOutput * (4 - angle) / 4;
		this.elevation = elevation;
		outputFromElevation ();
    }

	//calculate output with the influence of elevation	
	public void outputFromElevation(){

		originalOutput = baseOutput + this.elevation / 10;
	
	}

    public override string GetInfo()
    {
//        return "\nCurrent Direction: " + direction + "\nCurrent Power: " + output
//            + "\nMax Power: " + maxOutput;

		return "\nPower: " + originalOutput + "\nCurrent Elevation: " + elevation + "\nPower Loss: " + powerLoss.ToString("0.00");

    }

	void OnMouseDown()
	{
		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<TurbineInfo>());
		Debug.Log(GetInfo ());
	}
}
