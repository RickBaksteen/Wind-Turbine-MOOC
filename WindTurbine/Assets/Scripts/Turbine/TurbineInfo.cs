using UnityEngine;
using System.Collections;
using System;

public class TurbineInfo : InfoItem
{
    public string[] directions = { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };
    public int directionIndex = 0;
    public string direction;
    public int output = 140;
    public int maxOutput = 140;

    void Start()
    {
        direction = directions[directionIndex];
    }

    void Update()
    {
        CalculateOutput();
    }

    public void CalculateOutput()
    {
        //int wind = GameObject.FindGameObjectWithTag("wind").transform.GetComponent<WindManager>().windIndex;
		int wind = 0;
		int angle = Math.Abs(wind - directionIndex) % 4;

        if (Math.Abs(wind - directionIndex) == 4)
        {
            angle = 4;
        }
        output = maxOutput * (4 - angle) / 4;
    }

    public override string GetInfo()
    {
        return "\nCurrent Direction: " + direction + "\nCurrent Power: " + output
            + "\nMax Power: " + maxOutput;
    }

	void OnMouseDown()
	{
		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<TurbineInfo>());
		Debug.Log(GetInfo ());
	}
}
