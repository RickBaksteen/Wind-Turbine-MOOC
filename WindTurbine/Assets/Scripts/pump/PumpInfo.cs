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
        

    }

    void Update()
    {

		if (power <= 0) {

			pumpDamage = 0;
			//gameObject.transform.GetChild(1)
		
		} else {
		
			pumpDamage = power / 25 + 1;
		
		}
			
    }

    public override string GetInfo()
    {
//        return "Pump Time: " + pumpTimeBetween + "\nPump Ammount: " + pumpDamage + "\nCurrent Power: " + power
//            + "\nMax Power: " + maxPower + "\nPower Percentage: " + percentage;

		return "Pump\n\n\n\n" + "Attacking Speed: " + pumpTimeBetween + "\nDamage: " + pumpDamage + "\nCurrent Power: " + power;
    }

	void OnMouseDown()
	{
		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<PumpInfo>());
		Debug.Log(GetInfo ());
	}
}
