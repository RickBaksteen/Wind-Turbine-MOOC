using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PumpInfo : InfoItem
{
    public float pumpTimeBetween = 0.5f;        //pump rate(atk speed)
    public int pumpDamage = 10; //pump damage;
    public int currentPower = 0;    //Current Power(used to calculate AS,DMG)???
    public float percentage = 0.47f;    //Current power to Percentage of cap (example 47% to 100%)
    public int maxPower = 25;       //Max Power

	public int cost = 0;
	public int x;
	public int z;

	public int power = 0;

	public bool powerShow;

	void Start()
	{
		
		GameObject.FindGameObjectWithTag ("transformer").GetComponent<TransformerWorking> ().linkToWaterTower (transform);
		powerShow = false;

	}
	
	void Update()
	{
		
		if (power <= 0) {
			
			pumpDamage = 0;
			//gameObject.transform.GetChild(1)
			
		} else {
			
			pumpDamage = power / 25 + 1;
			
		}

		if (transform != VisualizationManager.visualizedObject || !powerShow) {
			
			powerShow = false;
			
		} else {
			
			powerShow = true;
			
		}

		if (powerShow) {
			
			transform.GetChild (2).GetChild (0).GetComponent<Text> ().color = Color.yellow;
			transform.GetChild (2).GetChild (0).GetComponent<Text> ().text = power + " kW";
			
		} else {
			
			transform.GetChild (2).GetChild (0).GetComponent<Text> ().text = "";
			
		}
		
	}
	
	public override string GetInfo()
	{
		//        return "Pump Time: " + pumpTimeBetween + "\nPump Ammount: " + pumpDamage + "\nCurrent Power: " + power
		//            + "\nMax Power: " + maxPower + "\nPower Percentage: " + percentage;
		
		return "Pump\n\n\n\n" + "Attack Speed: " + pumpTimeBetween + "\nDamage: " + pumpDamage + "\nReceived Power: " + power;
	}
	
	void OnMouseDown()
	{
		if (LockUI.OverGui) return;

		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<PumpInfo>());
		GameObject sellButton = GameObject.FindGameObjectWithTag ("sellButton");

		GameObject sellBtn = GameObject.FindGameObjectWithTag("sellButton");
		GameObject repairBtn = GameObject.FindGameObjectWithTag("repairButton");
		
		if (sellBtn != null)
			sellBtn.GetComponent<SellManager> ().disableButton ();
		
		if (repairBtn != null)
			repairBtn.GetComponent<RepairManager> ().disableButton ();
		
		Debug.Log(GetInfo ());

		VisualizationManager.visualizedObject = transform;
		powerShow = !powerShow;
	}
}
