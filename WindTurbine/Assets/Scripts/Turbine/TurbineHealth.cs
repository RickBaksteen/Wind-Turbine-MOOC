using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurbineHealth : MonoBehaviour {

	TurbineInfo myTurbineInfo;
	bool myTurbineIsWorking;
	bool myTurbineIsRepairing;

	// Use this for initialization
	void Start () {
		myTurbineInfo = transform.parent.parent.GetComponent<TurbineInfo> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		myTurbineIsWorking = myTurbineInfo.isWorking;
		myTurbineIsRepairing = myTurbineInfo.isReparing;
		
		if (myTurbineIsWorking) {
			
			transform.GetChild(2).GetComponent<Image>().fillAmount = 0;
			transform.GetChild(1).GetComponent<Image>().fillAmount = (float)myTurbineInfo.health / 100.0f;
			
			Color backgroundColor = transform.GetChild(0).GetComponent<Image>().color;
			
			if(backgroundColor.a!=0f)
				transform.GetChild(0).GetComponent<Image>().color = Color.red;
			
			
		}
		
		if (!myTurbineIsWorking) {
			
			transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
			
			if(!myTurbineIsRepairing)
			{
				transform.GetChild(2).GetComponent<Image>().fillAmount = 0;
				//transform.GetChild(0).GetComponent<Image>().color = Color.black;
				
				Color backgroundColor = transform.GetChild(0).GetComponent<Image>().color;
				
				if(backgroundColor.a!=0f)
					transform.GetChild(0).GetComponent<Image>().color = Color.black;
				
			}
			
			else
			{
				transform.GetChild(2).GetComponent<Image>().fillAmount = myTurbineInfo.timeAfterRepair / myTurbineInfo.timeForRepair;
			}
			
		}
		
		//transform.GetChild(3).GetComponent<Text>().text = myTurbineInfo.output + " kW";

	}

	public void enter(){
		
		//		Debug.Log ("Mouse Enter");
		
		if (Application.loadedLevelName == "Level1" || Application.loadedLevelName == "Level2" ) {
		
			Color color = transform.GetChild (0).GetComponent<Image> ().color;
			transform.GetChild (0).GetComponent<Image> ().color = new Color (color.r, color.g, color.b, 0f);
			
			color = transform.GetChild (1).GetComponent<Image> ().color;
			transform.GetChild (1).GetComponent<Image> ().color = new Color (color.r, color.g, color.b, 0f);
			
			color = transform.GetChild (2).GetComponent<Image> ().color;
			transform.GetChild (2).GetComponent<Image> ().color = new Color (color.r, color.g, color.b, 0f);
		
		} else {
		
			Color color = transform.GetChild (0).GetComponent<Image> ().color;
			transform.GetChild (0).GetComponent<Image> ().color = new Color(color.r, color.g, color.b, 1f);
			
			color = transform.GetChild (1).GetComponent<Image> ().color;
			transform.GetChild (1).GetComponent<Image> ().color = new Color(color.r, color.g, color.b, 1f);
			
			color = transform.GetChild (2).GetComponent<Image> ().color;
			transform.GetChild (2).GetComponent<Image> ().color = new Color(color.r, color.g, color.b, 1f);

		}
		
		if (myTurbineIsWorking) {
			
			transform.GetChild (3).GetComponent<Text> ().text = " " + myTurbineInfo.originalOutput + " kW";
			transform.GetChild (4).GetComponent<Text> ().text = "";
			
		} else {
			
			transform.GetChild (3).GetComponent<Text> ().text = " 0 kW";
			transform.GetChild (4).GetComponent<Text> ().text = "";
		}
		
	}
	
	public void enterWithPowerLoss(){
		
		//		Debug.Log ("Mouse Enter");
		
		Color color = transform.GetChild (0).GetComponent<Image> ().color;
		transform.GetChild (0).GetComponent<Image> ().color = new Color(color.r, color.g, color.b, 1f);
		
		color = transform.GetChild (1).GetComponent<Image> ().color;
		transform.GetChild (1).GetComponent<Image> ().color = new Color(color.r, color.g, color.b, 1f);
		
		color = transform.GetChild (2).GetComponent<Image> ().color;
		transform.GetChild (2).GetComponent<Image> ().color = new Color(color.r, color.g, color.b, 1f);
		
		
		if (myTurbineIsWorking) {
			
			transform.GetChild (3).GetComponent<Text> ().text = " " + myTurbineInfo.originalOutput + " kW";
			transform.GetChild (4).GetComponent<Text> ().text = "- " + myTurbineInfo.powerLoss + " kW";
			
		} else {
			
			transform.GetChild (3).GetComponent<Text> ().text = " 0 kW";
			transform.GetChild (4).GetComponent<Text> ().text = "";
		}
		
		
	}

	public void exit(){

//		Debug.Log ("Mouse Exit");

		Color color = transform.GetChild (0).GetComponent<Image> ().color;
		transform.GetChild (0).GetComponent<Image> ().color = new Color(color.r, color.g, color.b, 0f);
		
		color = transform.GetChild (1).GetComponent<Image> ().color;
		transform.GetChild (1).GetComponent<Image> ().color = new Color(color.r, color.g, color.b, 0f);
		
		color = transform.GetChild (2).GetComponent<Image> ().color;
		transform.GetChild (2).GetComponent<Image> ().color = new Color(color.r, color.g, color.b, 0f);

		transform.GetChild(3).GetComponent<Text>().text = "";
		transform.GetChild (4).GetComponent<Text> ().text = "";
	}
}
