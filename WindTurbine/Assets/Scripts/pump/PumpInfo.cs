using UnityEngine;
using System.Collections;
using System;

public class PumpInfo : InfoItem
{
    public float pumpTimeBetween = 0.5f;        //pump rate(atk speed)
    public int pumpDamage = 10; //pump damage;
    public int currentPower = 0;    //Current Power(used to calculate AS,DMG)???
    public float percentage = 0.47f;    //Current power to Percentage of cap (example 47% to 100%)
    public int maxPower = 25;       //Max Power

	public int power = 0;

    void Start()
    {
        
		try {

			Transform turbine = GameObject.FindGameObjectWithTag("turbine").transform;
			
			int distance = (int)Math.Abs(turbine.position.x - transform.position.x) + (int)Math.Abs(turbine.position.z - transform.position.z);
			distance /= 10;
			
			if (distance > 10)
				percentage = 0.47f;
			else
				percentage = (float)((distance - 10) * ((1 - 0.47f) / (1 - 10))) + 0.47f;
			
			currentPower = (int)(maxPower * percentage);

		}       
		catch (NullReferenceException ex) {

		}

    }

    void Update()
    {
		try {
			
			Transform turbine = GameObject.FindGameObjectWithTag("turbine").transform;
			
			int distance = (int)Math.Abs(turbine.position.x - transform.position.x) + (int)Math.Abs(turbine.position.z - transform.position.z);
			distance /= 10;
			
			if (distance > 10)
				percentage = 0.47f;
			else
				percentage = (float)((distance - 10) * ((1 - 0.47f) / (1 - 10))) + 0.47f;
			
			currentPower = (int)(maxPower * percentage);
			
		}       
		catch (NullReferenceException ex) {
			
		};

		pumpDamage = power / 25 + 1;
    }

    public override string GetInfo()
    {
//        return "Pump Time: " + pumpTimeBetween + "\nPump Ammount: " + pumpDamage + "\nCurrent Power: " + power
//            + "\nMax Power: " + maxPower + "\nPower Percentage: " + percentage;

		return "Pump Time: " + pumpTimeBetween + "\nPump Ammount: " + pumpDamage + "\nCurrent Power: " + power;
    }

	void OnMouseDown()
	{
		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<PumpInfo>());
		Debug.Log(GetInfo ());
	}
}
