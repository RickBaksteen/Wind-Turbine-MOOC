using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RepairManager : MonoBehaviour {

	public Transform repairObject;
	public TurbineInfo repairObjectInfo;

	// Use this for initialization
	void Start () {
		gameObject.transform.GetComponent<Button>().interactable = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (repairObject == null) {
		
		} 

		else {
		
			if (repairObjectInfo.health <= 10 || repairObjectInfo.isReparing) {
				

				if(!repairObjectInfo.isReparing && !repairObjectInfo.isWorking){
				
					gameObject.transform.GetComponent<Button>().interactable = false;
				
				}

				else{
				
					gameObject.transform.GetComponent<Button> ().interactable = true;
					
				}
				
			}

			else
			{
				gameObject.transform.GetComponent<Button> ().interactable = false;
			}
		
		}

	}

	public void Repair(){

		repairObjectInfo.Repair ();

	}

	public void proposeRepairTurbine(Transform newObject)
	{
		repairObject = newObject;
		repairObjectInfo = newObject.GetComponent<TurbineInfo> ();
	}
}
