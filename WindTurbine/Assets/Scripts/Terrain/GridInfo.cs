using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridInfo : InfoItem {
	
	public int Elevation;
	public int ExtraCost;
	
	public int GridType;
	
	public int x;
	public int z;
	public AudioClip click;
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
			print = "Terrain\n\n\n\n" + "Elevation: " + Elevation + "\nConstruction Cost: " + ExtraCost;
		}
		if(GridType == 1){
			print = "River\n\n\n\n";
		}
		
		return print;
	}
	
	void OnMouseDown()
	{
		if (LockUI.OverGui) return;

		//sellButton.GetComponent<SellManager>().disableButton();

		GameObject sellBtn = GameObject.FindGameObjectWithTag("sellButton");
		GameObject repairBtn = GameObject.FindGameObjectWithTag("repairButton");
		
		if (sellBtn != null)
			sellBtn.GetComponent<SellManager> ().disableButton ();
		
		if (repairBtn != null)
			repairBtn.GetComponent<RepairManager> ().disableButton ();

		AudioSource.PlayClipAtPoint (click, Camera.main.transform.position, 0.8f);
		CreateManager createManager = GameObject.FindGameObjectWithTag ("createManager").transform.GetComponent<CreateManager> ();
		bool creating = createManager.creating;
		CreateManager.createType createType = createManager.currentType;
		
		if (creating) {
			
			if(this.GridType == 1 || TerrainInfo.placeItemInfo[x, z] == 1){
				
				createManager.creating = false;
				return;
				
			}
			
			if(createType == CreateManager.createType.turbine){
				
				Transform newTransform = createManager.newTransform;
				Quaternion rotation = createManager.rotation;
				int maxOutput = createManager.maxOutput; 
				int directionIndex = createManager.directionIndex;
				int cost = createManager.cost;
				float timeForWork = createManager.timeForWork;
				Vector3 pos = transform.position;
				pos.y += 1;
				Transform newObject = (Transform)Instantiate(newTransform, pos, rotation);
				
				TurbineInfo newTurbineInfo = newObject.GetComponent<TurbineInfo> ();
				
				newTurbineInfo.maxOutput = maxOutput;
				newTurbineInfo.CalculateOutput(Elevation);
				newTurbineInfo.directionIndex = directionIndex % 8;
				newTurbineInfo.cost = cost;
				newTurbineInfo.timeForWork = timeForWork;
				newTurbineInfo.turbineColor = createManager.turbineColor;
				Debug.Log(timeForWork);
				newTurbineInfo.x = x;
				newTurbineInfo.z = z;
				
				if(MoneyManager.money < cost + ExtraCost){
					createManager.finishCreateTurbine();
					Destroy(newObject.gameObject);
				}
				else{
					MoneyManager.money -= cost + ExtraCost;
					CreateManager.turbineNum++;
					createManager.finishCreateTurbine();
					TerrainInfo.placeItemInfo[x, z] = 1;
				}
			}
			
			//Create Pump here
			else if(createType == CreateManager.createType.pump)
			{
				
			}
			
			//Create Transformer here
			else if(createType == CreateManager.createType.transformer)
			{
				
			}
			
			
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

	public void OnMouseEnter (){

//		Debug.Log ("enter");
//		GameObject.Find ("TerrainInformation").transform.GetChild (0).GetComponent<CanvasGroup> ().alpha = 0.7f;
//		GameObject.Find ("TerrainInformation").transform.GetChild (0).GetChild(1).GetComponent<Text> ().text = "Elevation: " + Elevation + "\n" + "Extra Cost: " + ExtraCost + " TC";

		CreateManager createManager = GameObject.FindGameObjectWithTag ("createManager").transform.GetComponent<CreateManager> ();

		Debug.Log ("enter");
		transform.GetChild (0).GetComponent<CanvasGroup> ().alpha = 0.7f;

		if (!createManager.creating)
			transform.GetChild (0).GetChild(1).GetComponent<Text> ().text = "Elevation: " + Elevation + "\n" + "Extra Cost: " + ExtraCost + " TC";
		else
			transform.GetChild (0).GetChild(1).GetComponent<Text> ().text = "Elevation: " + Elevation + "\n" + "Extra Cost: " + ExtraCost + " TC" + "\nTotal Cost: " + createManager.cost + " TC";

	}

	public void OnMouseExit(){
		Debug.Log ("exit");
//		GameObject.Find ("TerrainInformation").transform.GetChild (0).GetComponent<CanvasGroup> ().alpha = 0f;
//		GameObject.Find ("TerrainInformation").transform.GetChild (0).GetChild(1).GetComponent<Text> ().text = "";

		Debug.Log ("enter");
		transform.GetChild (0).GetComponent<CanvasGroup> ().alpha = 0f;
		transform.GetChild (0).GetChild (1).GetComponent<Text> ().text = "";

	}
}
