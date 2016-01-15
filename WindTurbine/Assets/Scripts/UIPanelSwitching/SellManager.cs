using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SellManager : MonoBehaviour {

	public GameObject sellingTurbine;
	public GameObject sellingPump;
	public GameObject sellingTransformer;

	public enum itemType {Turbine, Pump, Transformer};
	public itemType sellingType;

	public int sellingPrice;

	// Use this for initialization
	void Start () {
		gameObject.transform.GetComponent<Button>().interactable = false;

		disableButton ();

	}
	
	// Update is called once per frame
	void Update () {
	
		if (sellingTurbine == null)
			return;
		
		
		if (!sellingTurbine.transform.GetComponent<TurbineInfo> ().isWorking && !sellingTurbine.transform.GetComponent<TurbineInfo> ().isReparing) {
			
			transform.GetChild (0).GetComponent<Text> ().text = "Discard";
			sellingPrice = 0;
			
		} else {
			
			transform.GetChild(0).GetComponent<Text>().text = "Sell";
			sellingPrice = sellingTurbine.transform.GetComponent<TurbineInfo> ().cost/2;
			
		}

	}

	public void sell()
	{
		switch (sellingType) {

			case itemType.Turbine:

				MoneyManager.money += sellingPrice;
				Transform transformer = sellingTurbine.transform.GetComponent<TurbineWorking>().transformerForTurbine;
				transformer.GetComponent<TransformerForTurbineWorking> ().unlinkTurbine (sellingTurbine.transform);
				
				int x = sellingTurbine.transform.GetComponent<TurbineInfo> ().x;
				int z = sellingTurbine.transform.GetComponent<TurbineInfo> ().z;
				
				TerrainInfo.placeItemInfo [x, z] = 0;
				Destroy (sellingTurbine.gameObject);
				CreateManager.turbineNum--;
				gameObject.transform.GetComponent<Button>().interactable = false;

				break;

			case itemType.Pump:
				break;

			case itemType.Transformer:
				break;

		}




	}


	public void proposeSellTurbine(GameObject newGameObject)
	{
		gameObject.transform.GetComponent<Button>().interactable = true;
		sellingTurbine = newGameObject;
		sellingType = itemType.Turbine; 
	}

	public void proposeSellPump(GameObject newGameObject){
		gameObject.transform.GetComponent<Button>().interactable = true;
		sellingPump = newGameObject;
		sellingType = itemType.Pump; 
	}

	public void proposeSellTransformer(GameObject newGameObject){
		gameObject.transform.GetComponent<Button>().interactable = true;
		sellingTransformer = newGameObject;
		sellingType = itemType.Transformer; 
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
