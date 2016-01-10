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

	void Start(){
	
		lossK = 0.00001f;
		powerShow = false;

	}

	void Update(){
	
		if (Application.loadedLevelName == "Level1")
			powerLoss = 0;
		else
			powerLoss = (int)(lossK * originalPower * originalPower * powerLineInfo.length(transform.position, gameObject.transform.GetComponent<TransformerForTurbineWorking>().poweredTransformer.position));
		
		outputPower = Math.Max(originalPower - powerLoss, 0);


		if (transform != VisualizationManager.visualizedObject || !powerShow) {
			
			powerShow = false;
			
		} else {
			
			powerShow = true;
			
		}


		if (powerShow) {
			
			transform.GetChild (1).GetChild (0).GetComponent<Text> ().text = originalPower + " kW";
			
		} else {
			
			transform.GetChild (1).GetChild (0).GetComponent<Text> ().text = "";
			
		}
	
	}


	public override string GetInfo()
	{
		return "Wind Turbine Transformer\n\n\n\n" + "Received Power: " + originalPower;
	}
	
	void OnMouseDown()
	{
		if (LockUI.OverGui) return;

		AudioSource.PlayClipAtPoint (click, Camera.main.transform.position);
		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<TransformerForTurbineInfo>());
		//Debug.Log(GetInfo ());

		VisualizationManager.visualizedObject = transform;
		powerShow = !powerShow;
	}
}
