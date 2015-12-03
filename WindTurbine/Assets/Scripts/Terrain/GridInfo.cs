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
		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<GridInfo>());
		Debug.Log(GetInfo ());
	}
}
