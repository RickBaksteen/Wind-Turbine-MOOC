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
	public float timeForWork;
	public Color turbineColor;

	public bool creating;

	public static bool anyButtonCreate;

	// Use this for initialization
	void Start () {
		rotation = new Quaternion (-0.5f, -0.5f, -0.5f, 0.5f);
		creating = false;
	}


	void Awake()
	{
	
		if(Application.loadedLevelName == "Level1_1"||Application.loadedLevelName == "Level1_2"||Application.loadedLevelName == "Level2_1"||Application.loadedLevelName == "Level2_2")
			cost = 250;
		
		else if(Application.loadedLevelName == "Level3_2"){
			cost = 200;
			
		}else
			cost = 100;

		turbineColor = Color.white;

	}
	
	// Update is called once per frame
	void Update () {

		if (MoneyManager.money < cost || CreateManager.turbineNum >= CreateManager.turbineNumLimit || creating || WindTurbineBtnInfo.anyButtonCreate) {
		
			transform.GetComponent<Button>().interactable = false;
		
		}

		else {

			transform.GetComponent<Button>().interactable = true;

		}

	}

	public override string GetInfo()
	{
		return "Turbine\n\n\n\n" + "\nOriginal Power: " + maxOutput + "\nCost: " + cost+ " TC";
	}

	public void createTurbine(){


	
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			GameObject.FindGameObjectWithTag ("createManager").GetComponent<CreateManager> ().createTurbine (windTurbine, rotation, maxOutput,directionIndex, cost, transform, timeForWork, turbineColor);
			GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
			GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (transform.GetComponent<WindTurbineBtnInfo>());
		} else if (eventData.button == PointerEventData.InputButton.Middle) {
//			Debug.Log ("Middle click");
		} else if (eventData.button == PointerEventData.InputButton.Right) {
//			Debug.Log ("Right click");
			if(creating||WindTurbineBtnInfo.anyButtonCreate)
			{
				anyButtonCreate = false;
				GameObject.FindGameObjectWithTag ("createManager").GetComponent<CreateManager> ().finishCreateTurbine();
			}
		}
	}
}
