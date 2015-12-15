using UnityEngine;
using System.Collections;

public class GridInfo : InfoItem {

	public int Elevation;
	public int ExtraCost;

	public int GridType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override string GetInfo()
	{
		string print = "";
		
		if(GridType == 0){
			print = "TerrainHolder Elevation: " + Elevation + "\nConstruction Cost: " + ExtraCost;
		}
		if(GridType == 1){
			print = "WaterRoute Elevation: " + Elevation + "\nConstruction Cost: " + ExtraCost;
		}

		return print;
	}

	void OnMouseDown()
	{
		CreateManager createManager = GameObject.FindGameObjectWithTag ("createManager").transform.GetComponent<CreateManager> ();
		bool creating = createManager.creating;

		if (creating) {

			if(this.GridType == 1){

				createManager.creating = false;
				return;

			}

			Transform newTransform = createManager.newTransform;
			Quaternion rotation = createManager.rotation;
			int maxOutput = createManager.maxOutput;
			int directionIndex = createManager.directionIndex;
			int cost = createManager.cost;
			Vector3 pos = transform.position;
			pos.y += 1;
			Transform newObject = (Transform)Instantiate(newTransform, pos, rotation);

			TurbineInfo newTurbineInfo = newObject.GetComponent<TurbineInfo> ();

			newTurbineInfo.maxOutput = maxOutput;
			newTurbineInfo.CalculateOutput(Elevation);
			newTurbineInfo.directionIndex = directionIndex % 8;
			newTurbineInfo.cost = cost;

			MoneyManager.money -= cost + ExtraCost;
			createManager.turbineNum++;
			createManager.creating = false;
		}

		if (!creating) {
			GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
			GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<GridInfo>());
			Debug.Log(GetInfo ());
			
			GameObject.FindGameObjectWithTag ("createManager").transform.position = gameObject.transform.position;
		}
	}

	public void setAttribute(){

		ExtraCost = Elevation;

	}
}
