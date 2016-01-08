using UnityEngine;
using System.Collections;
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
		
	void Start(){
	
		lossK = 0.00001f;
		powerShow = false;

	}

	void Update(){
	
		if (Application.loadedLevelName == "Level1")
			powerLoss = 0;
		else
			powerLoss = (int)(lossK * originalPower * originalPower * powerLineInfo.length(transform.position, gameObject.transform.GetComponent<TransformerForTurbineWorking>().poweredTransformer.position));
		
		outputPower = originalPower - powerLoss;

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
		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<TransformerForTurbineInfo>());
		//Debug.Log(GetInfo ());

		if (!powerShow) {
			
			powerShow = true;
			
		} 
		else {
			
			powerShow = false;
			
		}
	}
}
