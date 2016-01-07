﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SellManager : MonoBehaviour {

	public GameObject sellingTurbine;
	public GameObject sellingPump;
	public GameObject sellingTransformer;

	public enum itemType {Turbine, Pump, Transformer};
	public itemType sellingType;
	public AudioClip coins;

	// Use this for initialization
	void Start () {
		gameObject.transform.GetComponent<Button>().interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void sell()
	{
		switch (sellingType) {

			case itemType.Turbine:
				AudioSource.PlayClipAtPoint (coins, Camera.main.transform.position);
				MoneyManager.money += (int)(sellingTurbine.transform.GetComponent<TurbineInfo> ().cost * 0.5);
				Transform transformer = sellingTurbine.transform.GetComponent<TurbineWorking>().transformerForTurbine;
				transformer.GetComponent<TransformerForTurbineWorking> ().unlinkTurbine (sellingTurbine.transform);
				
				int x = sellingTurbine.transform.GetComponent<TurbineInfo> ().x;
				int z = sellingTurbine.transform.GetComponent<TurbineInfo> ().z;
				
				TerrainInfo.placeItemInfo [x, z] = 0;
				Destroy (sellingTurbine);
				CreateManager.turbineNum--;
				gameObject.transform.GetComponent<Button>().interactable = false;

				break;

			case itemType.Pump:
				AudioSource.PlayClipAtPoint (coins, Camera.main.transform.position);
				MoneyManager.money += (int)(sellingPump.transform.GetComponent<PumpInfo> ().cost * 0.5);
				Transform myTransformer = GameObject.FindGameObjectWithTag("transformer").transform;
				myTransformer.GetComponent<TransformerWorking> ().unLinkToWaterTower (sellingPump.transform);
				
				int pumpX = sellingPump.transform.GetComponent<PumpInfo> ().x;
				int pumpZ = sellingPump.transform.GetComponent<PumpInfo> ().z;
				
				TerrainInfo.placeItemInfo [pumpX, pumpZ] = 0;
				Destroy (sellingPump);
				//CreateManager.turbineNum--;
				gameObject.transform.GetComponent<Button>().interactable = false;

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

}
