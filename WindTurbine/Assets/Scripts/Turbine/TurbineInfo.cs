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
	
	public int health = 100;			//Health percentage
	public float timeForWork;		//Seconds before repair
	public float timeAfterWork = 0f;
	
	public float timeForRepair;
	public float timeAfterRepair = 0f;

	public float timeForPowerLossShow;
	public float timeAfterPowerLossShow;
	
	public bool isWorking;
	public bool	isReparing; 
	
	public int costForRepair;
	public AudioClip click;
	public AudioClip breakdown;
	public AudioClip repair;
	public AudioClip construct;
	private AudioSource working;

	public static int healthPercBeforeReparing;
	public Color turbineColor;

	bool healthShow = false;
	bool powerLossShow;
	
	void Awake(){

		//turbineColor = Color.white;
		lossK = 0.001f;

		if(Application.loadedLevelName == "Level1_1"||Application.loadedLevelName == "Level1_2"||Application.loadedLevelName == "Level2_1"||Application.loadedLevelName == "Level2_2")
			cost = 250;
		
		
		else if(Application.loadedLevelName == "Level3_2"){
			cost = 200;
			
		}
		
		else
			cost = 100;
	}

	void Start()
	{
		working = GetComponent<AudioSource>();
		AudioSource.PlayClipAtPoint(construct, Camera.main.transform.position);
		direction = directions[directionIndex];

		timeAfterWork = 0;
		
		isWorking = true;
		isReparing = false;
		
		//timeForWork = 30f;

		if (Application.loadedLevelName == "Level3_1") {
		
			timeForRepair = 25f;
			costForRepair = 25;
			TurbineInfo.healthPercBeforeReparing = 50;
			timeForPowerLossShow = 4f;

		} else {
		
			timeForRepair = 15f;
			costForRepair = 30;
			timeForPowerLossShow = 4f;
			TurbineInfo.healthPercBeforeReparing = 25;
		}
		
		healthShow = true;
		powerLossShow = true;

	}
	
	void Update()
	{
		if (isWorking) {
			working.mute = false;
			brushTurbine(turbineColor);
			//CalculateOutput();
			if (Application.loadedLevelName == "Level1" || Application.loadedLevelName == "Level1_1"|| Application.loadedLevelName == "Level1_2"|| Application.loadedLevelName == "Level1_3")
				powerLoss = 0;
			else{
				powerLoss = (int)(lossK * originalOutput * originalOutput * powerLineInfo.length(transform.position, gameObject.transform.GetComponent<TurbineWorking>().transformerForTurbine.position));
				powerLoss = Math.Min(originalOutput, powerLoss);
			}
			
			output = originalOutput - powerLoss;
			
			timeAfterWork += Time.deltaTime;
			timeAfterPowerLossShow += Time.deltaTime;

			if (Application.loadedLevelName != "Level1"&& Application.loadedLevelName != "Level1_1" && Application.loadedLevelName != "Level1_2"  && Application.loadedLevelName != "Level1_3"  && Application.loadedLevelName != "Level1_3" && Application.loadedLevelName != "Level2" && Application.loadedLevelName != "Level2_1" && Application.loadedLevelName != "Level2_2" && Application.loadedLevelName != "Level2_3")
				health = 100 - (int)(100 * timeAfterWork/timeForWork);
			
			if(health <= 0)
			{
				AudioSource.PlayClipAtPoint(breakdown, Camera.main.transform.position, 0.6f);
				isWorking = false;
				isReparing = true;
			}

			if(timeAfterPowerLossShow >= timeForPowerLossShow)
			{
				powerLossShow = false;
			}
		}
		
		if (!isWorking) {
			working.mute = true;
			powerLoss = originalOutput;
			output = 0;
			
			if (isReparing) {
				
				timeAfterRepair += Time.deltaTime;
				
				if(timeAfterRepair >= timeForRepair){
					
					isReparing = false;
					
				}
				
			}
			
			if(!isReparing)
			{

				brushTurbine(Color.black);
				working.mute = true;				
			}
			
		}
		
		if (transform == VisualizationManager.visualizedObject || health <= TurbineInfo.healthPercBeforeReparing) {
			
			healthShow = true;
			
		} else {
			
			healthShow = false;
			
		}
		
		if (powerLossShow) {
			
			if(Application.loadedLevelName == "Level1" || Application.loadedLevelName == "Level1" || Application.loadedLevelName == "Level1_1"|| Application.loadedLevelName == "Level1_2"|| Application.loadedLevelName == "Level1_3")
				transform.GetChild (1).GetChild (0).GetComponent<TurbineHealth> ().enter ();
			else
				transform.GetChild (1).GetChild (0).GetComponent<TurbineHealth> ().enterWithPowerLoss ();
			
		}
		
		else if (healthShow) {
			
			transform.GetChild (1).GetChild (0).GetComponent<TurbineHealth> ().enter ();
			
		}
		
		else if (!healthShow) {
			
			transform.GetChild (1).GetChild (0).GetComponent<TurbineHealth> ().exit ();
			
		}
		
	}
	
	public void CalculateOutput(int elevation)
	{
		this.elevation = elevation;
		outputFromElevation ();
	}
	
	//calculate output with the influence of elevation	
	public void outputFromElevation(){
		
		originalOutput = maxOutput + this.elevation / 1;
		
	}
	
	public override string GetInfo()
	{
		//        return "\nCurrent Direction: " + direction + "\nCurrent Power: " + output
		//            + "\nMax Power: " + maxOutput;
		
		//		return "\nOriginal Power: " + originalOutput + "\nCurrent Power: " + output + "\nCurrent Elevation: " + elevation + "\nPower Loss: " + powerLoss.ToString("0.00")
		//			+ "\nCost: $ " + cost;
		
		float timeRemains;
		
		if (!isWorking && !isReparing)
			return "Turbine\n\n\n\nTurbine is not working any more.\nRenew Cost: " + cost +" TC";
		
		else if (!isWorking && isReparing) {
			
			timeRemains = timeForRepair - timeAfterRepair;
			return "Turbine\n\n\n\nTurbine is waiting to be repaired.\nTime remaining until total loss: " + (int)timeRemains + "s\nRepair Cost: " + costForRepair + " TC";
			
		}
		
		return "Turbine\n\n\n\n" + "\nPower Output: " + originalOutput+ "\nPower Lost Over Distance: " + powerLoss + "\nSelling Price: " + cost/2 + " TC";
		
	}
	
	void OnMouseDown()
	{
		if (LockUI.OverGui) return;

		GameObject sellBtn = GameObject.FindGameObjectWithTag("sellButton");
		GameObject repairBtn = GameObject.FindGameObjectWithTag("repairButton");

		if (sellBtn != null)
			sellBtn.GetComponent<SellManager> ().enableButton ();

		if (repairBtn != null)
			repairBtn.GetComponent<RepairManager> ().enableButton ();


		AudioSource.PlayClipAtPoint (click, Camera.main.transform.position, 0.4f);
		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<TurbineInfo>());

		if (repairBtn!=null) {
		
			//GameObject repairButton = GameObject.FindGameObjectWithTag ("repairButton");
			repairBtn.GetComponent<RepairManager> ().proposeRepairTurbine (transform);
		
		}

		//GameObject sellButton = GameObject.FindGameObjectWithTag ("sellButton");
		sellBtn.GetComponent<SellManager>().proposeSellTurbine(this.gameObject);
		
		Debug.Log(GetInfo ());
		
		VisualizationManager.visualizedObject = transform;
		
	}
	
	
	//For repair the windTurbine
	public void Repair(int cost)
	{
		AudioSource.PlayClipAtPoint (repair, Camera.main.transform.position, 0.4f);
		MoneyManager.money -= cost;
		timeAfterWork = 0;
		timeAfterRepair = 0;
		timeAfterPowerLossShow = 0;
		isWorking = true;
		isReparing = false;
		powerLossShow = true;
	}

	public void brushTurbine(Color color){

		transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_Color", color);
		transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().material.SetColor("_Color", color);

	}

	public int calculatePowerLoss(int power){

		int loss;

		Debug.Log ("power: " + power);
		Debug.Log ("lossK: " + lossK);

		if (Application.loadedLevelName == "Level1" || Application.loadedLevelName == "Level1_1"|| Application.loadedLevelName == "Level1_2"|| Application.loadedLevelName == "Level1_3")
			loss = 0;
		else{
			loss = (int)(lossK * power * power * powerLineInfo.length(transform.position, gameObject.transform.GetComponent<TurbineWorking>().transformerForTurbine.position));
			loss = Math.Min(power, loss);

			Debug.Log(powerLineInfo.length(transform.position, gameObject.transform.GetComponent<TurbineWorking>().transformerForTurbine.position));
		}

		Debug.Log ("loss: " + loss);

		return loss;

	}
}
