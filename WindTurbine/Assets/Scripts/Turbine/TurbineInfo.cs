using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

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
	public int cost;

    void Start()
    {
        direction = directions[directionIndex];
    }

    void Update()
    {
        //CalculateOutput();
		if (Application.loadedLevelName == "Level1")
			powerLoss = 1f;
		else
			powerLoss = gameObject.transform.GetChild (1).GetComponent<powerLineInfo> ().loss;
		//powerLoss = 1f;
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

		return "\nOriginal Power: " + originalOutput + "\nCurrent Power: " + output + "\nCurrent Elevation: " + elevation + "\nPower Loss: " + powerLoss.ToString("0.00")
			+ "\nCost: $ " + cost;

    }

	void OnMouseDown()
	{
		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<TurbineInfo>());
		GameObject sellButton = GameObject.FindGameObjectWithTag ("sellButton");
		sellButton.GetComponent<SellManager>().proposeSell(this.gameObject);

		Debug.Log(GetInfo ());
	}
}
