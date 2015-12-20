using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class TurbineInfo : InfoItem
{
    public string[] directions = { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };
    public int directionIndex = 0;
    public string direction;
	public int originalOutput = 0;		//maxOutput+ Elevation effect
	public int output = 0;				//After powerLoss
    public int maxOutput = 140;
	public int elevation;
	public int powerLoss;
	public int cost;

	public float lossK;

	public int x;
	public int z;

    void Start()
    {
        direction = directions[directionIndex];
		lossK = 0.0001f;
    }

    void Update()
    {
        //CalculateOutput();
		if (Application.loadedLevelName == "Level1")
			powerLoss = 0;
		else
			powerLoss = (int)(lossK * originalOutput * originalOutput * powerLineInfo.length(transform.position, gameObject.transform.GetComponent<TurbineWorking>().transformerForTurbine.position));

		output = originalOutput - powerLoss;
    }

    public void CalculateOutput(int elevation)
    {
		this.elevation = elevation;
		outputFromElevation ();
    }

	//calculate output with the influence of elevation	
	public void outputFromElevation(){

		originalOutput = maxOutput + this.elevation / 10;
	
	}

    public override string GetInfo()
    {
//        return "\nCurrent Direction: " + direction + "\nCurrent Power: " + output
//            + "\nMax Power: " + maxOutput;

//		return "\nOriginal Power: " + originalOutput + "\nCurrent Power: " + output + "\nCurrent Elevation: " + elevation + "\nPower Loss: " + powerLoss.ToString("0.00")
//			+ "\nCost: $ " + cost;

		return "Turbine\n\n\n\n" + "\nPower Output: " + originalOutput + "\nSelling Cost: $ " + cost/2;

    }

	void OnMouseDown()
	{
		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<TurbineInfo>());
		GameObject sellButton = GameObject.FindGameObjectWithTag ("sellButton");
		sellButton.GetComponent<SellManager>().proposeSellTurbine(this.gameObject);

		Debug.Log(GetInfo ());
	}
}
