using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RepairManager : MonoBehaviour {

	public Transform repairObject;
	public TurbineInfo repairObjectInfo;
	public int repairPrice;

	// Use this for initialization
	void Start () {
		gameObject.transform.GetComponent<Button>().interactable = false;

		disableButton ();
	}
	
	// Update is called once per frame
	void Update () {

		if (repairObject == null) {
		
		} 

		else {
		
			if (repairObjectInfo.health <= TurbineInfo.healthPercBeforeReparing) {
				
				gameObject.transform.GetComponent<Button> ().interactable = true;

				if(!repairObjectInfo.isWorking && !repairObjectInfo.isReparing){

					gameObject.transform.GetChild(0).GetComponent<Text>().text = "Renew";
					repairPrice = repairObjectInfo.cost;

				}

				else{

					gameObject.transform.GetChild(0).GetComponent<Text>().text = "Repair";
					repairPrice = repairObjectInfo.costForRepair;

				}

				if(repairPrice > MoneyManager.money)
					gameObject.transform.GetComponent<Button> ().interactable = false;
				
			}

			else
			{
				gameObject.transform.GetComponent<Button> ().interactable = false;
			}
		
		}

	}

	public void Repair(){

		repairObjectInfo.Repair (repairPrice);

	}

	public void proposeRepairTurbine(Transform newObject)
	{
		repairObject = newObject;
		repairObjectInfo = newObject.GetComponent<TurbineInfo> ();
	}

	public void disableButton(){
		
		transform.GetComponent<CanvasGroup> ().alpha = 0;
		transform.GetComponent<CanvasGroup> ().interactable = false;
		
	}
	
	public void enableButton(){
		
		transform.GetComponent<CanvasGroup> ().alpha = 1;
		transform.GetComponent<CanvasGroup> ().interactable = true;
		
	}
}
