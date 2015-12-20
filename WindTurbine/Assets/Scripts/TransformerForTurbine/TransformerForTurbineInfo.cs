using UnityEngine;
using System.Collections;

public class TransformerForTurbineInfo : InfoItem {

	public int originalPower = 0;
	public int cost = 0;
	public int outputPower;

	public float lossK;
	public int powerLoss;
	
	public int x;
	public int z;
		
	void Start(){
	
		lossK = 0.00001f;

	}

	void Update(){
	
		if (Application.loadedLevelName == "Level1")
			powerLoss = 0;
		else
			powerLoss = (int)(lossK * originalPower * originalPower * powerLineInfo.length(transform.position, gameObject.transform.GetComponent<TransformerForTurbineWorking>().poweredTransformer.position));
		
		outputPower = originalPower - powerLoss;
	
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
	}
}
