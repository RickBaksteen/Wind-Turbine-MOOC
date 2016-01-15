using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class TransformerForTurbineInfo : InfoItem {

	public int originalPower = 0;
	public int cost = 0;
	public int outputPower;

	public float lossK;
	public int powerLoss;
	
	public int x;
	public int z;

	public bool powerShow;
	public AudioClip click;

	public int previousPower;

	public float timeAfterShowingNewPower;
	public float timeForShowingNewPower;
	public bool newPowerShow;

	public int plusPower;
	public int minusPower;


	void Start(){
	
		lossK = 0.00001f;
		powerShow = false;

		timeAfterShowingNewPower = 0f;
		timeForShowingNewPower = 4f;
		newPowerShow = false;

		plusPower = 0;
		minusPower = 0;

	}

	void Update(){
	
		if (Application.loadedLevelName == "Level1" || Application.loadedLevelName == "Level1_1"|| Application.loadedLevelName == "Level1_2"|| Application.loadedLevelName == "Level1_3")
			powerLoss = 0;
		else
			powerLoss = (int)(lossK * originalPower * originalPower * powerLineInfo.length(transform.position, gameObject.transform.GetComponent<TransformerForTurbineWorking>().poweredTransformer.position));
		
		outputPower = Math.Max(originalPower - powerLoss, 0);
		
		
		if (transform != VisualizationManager.visualizedObject || !powerShow) {
			
			powerShow = false;
			
		} else {
			
			powerShow = true;
			
		}
		
		if (newPowerShow) {
			
			timeAfterShowingNewPower += Time.deltaTime;
			if(timeAfterShowingNewPower >= timeForShowingNewPower){
				unshowNewPower();
			}
			
		}
		
		if (newPowerShow && Application.loadedLevelName!="Level1" && Application.loadedLevelName!="Level1_1" && Application.loadedLevelName!="Level1_2") {
			
			int powerAdded = plusPower-minusPower;
			
			//transform.GetChild (1).GetChild (0).GetComponent<Text> ().text = originalPower + " kW";
			transform.GetChild (1).GetChild (0).GetComponent<Text> ().color = Color.green;
			transform.GetChild (1).GetChild (0).GetComponent<Text> ().text = "+ " + powerAdded + " kW";
			//transform.GetChild (1).GetChild (0).GetComponent<Text> ().text = previousPower + " kW";
			//transform.GetChild (1).GetChild (1).GetComponent<Text> ().text = "+ " + plusPower + " kW";
			//transform.GetChild (1).GetChild (2).GetComponent<Text> ().text = "- "+ minusPower + " kW";
			
		} else if (powerShow) {
			
			transform.GetChild (1).GetChild (0).GetComponent<Text> ().text = originalPower + " kW";
			
		} else {
			
			transform.GetChild (1).GetChild (0).GetComponent<Text> ().text = "";
			
		}
	
	}


	public void showNewPower(Transform turbine){
		
		timeAfterShowingNewPower = 0f;
		newPowerShow = true;
		//turbine.GetComponent<TurbineInfo> ().calculatePowerLoss ();
		plusPower += turbine.GetComponent<TurbineInfo>().originalOutput;
		minusPower += turbine.GetComponent<TurbineInfo>().calculatePowerLoss(turbine.GetComponent<TurbineInfo>().originalOutput);
	}
	
	public void unshowNewPower(){
		
		newPowerShow = false;
		previousPower = originalPower;
		plusPower = 0;
		minusPower = 0;
		
		transform.GetChild (1).GetChild (0).GetComponent<Text> ().color = Color.yellow;
		transform.GetChild (1).GetChild (0).GetComponent<Text> ().text = "";
		transform.GetChild (1).GetChild (1).GetComponent<Text> ().text = "";
		transform.GetChild (1).GetChild (2).GetComponent<Text> ().text = "";
	}


	public override string GetInfo()
	{
		return "Wind Turbine Transformer\n\n\n\n" + "Received Power: " + originalPower;
	}
	
	void OnMouseDown()
	{
		if (LockUI.OverGui) return;

		GameObject sellBtn = GameObject.FindGameObjectWithTag("sellButton");
		GameObject repairBtn = GameObject.FindGameObjectWithTag("repairButton");
		
		if (sellBtn != null)
			sellBtn.GetComponent<SellManager> ().disableButton ();
		
		if (repairBtn != null)
			repairBtn.GetComponent<RepairManager> ().disableButton ();

		AudioSource.PlayClipAtPoint (click, Camera.main.transform.position);
		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<TransformerForTurbineInfo>());
		//Debug.Log(GetInfo ());

		VisualizationManager.visualizedObject = transform;
		powerShow = !powerShow;
	}
}
