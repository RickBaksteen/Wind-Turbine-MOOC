using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WindTurbineBtnInfo : InfoItem, IPointerClickHandler {

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

		if (MoneyManager.money < cost || CreateManager.turbineNum >= CreateManager.turbineNumLimit) {
		
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

		transform.GetComponent<Button> ().interactable = false;
		GameObject.FindGameObjectWithTag ("createManager").GetComponent<CreateManager> ().createTurbine (windTurbine, rotation, maxOutput,directionIndex, cost);
		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (transform.GetComponent<WindTurbineBtnInfo>());
	
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			transform.GetComponent<Button>().interactable = false;
//			Debug.Log ("Left click");
		} else if (eventData.button == PointerEventData.InputButton.Middle) {
//			Debug.Log ("Middle click");
		} else if (eventData.button == PointerEventData.InputButton.Right) {
//			Debug.Log ("Right click");
			GameObject.FindGameObjectWithTag ("createManager").GetComponent<CreateManager> ().creating = false;
		}
	}
}
