using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WindTurbineBtnInfo : InfoItem {

	public Transform windTurbine;
	public Quaternion rotation;

	public int maxOutput;
	public int directionIndex;
	public int cost;

	// Use this for initialization
	void Start () {
		rotation = new Quaternion (-0.5f, -0.5f, -0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {

		if (MoneyManager.money < cost || GameObject.FindGameObjectWithTag("createManager").GetComponent<CreateManager>().turbineNum >= CreateManager.turbineNumLimit) {
		
			transform.GetComponent<Button>().interactable = false;
		
		}

		else {

			transform.GetComponent<Button>().interactable = true;

		}

	}

	public override string GetInfo()
	{
		return "\nPower: " + maxOutput + "\nCost: $ " + cost;
	}

	public void createTurbine(){

		GameObject.FindGameObjectWithTag ("createManager").GetComponent<CreateManager> ().createTransform (windTurbine, rotation, maxOutput,directionIndex, cost);

		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (transform.GetComponent<WindTurbineBtnInfo>());

	}
}
