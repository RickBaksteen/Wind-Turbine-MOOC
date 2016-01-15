using UnityEngine;
using System.Collections;

public class CreateManager : MonoBehaviour {

	public bool creating;
	public Transform newTransform;
	public Quaternion rotation;

	public Transform currentButton;

	//Parameter for Turbine
	public int maxOutput;
	public int directionIndex;
	public int cost;
	public float timeForWork;
	public Color turbineColor;

	//Parameter for Pump
	public float pumpTimeBetween;

	//Parameter for Transformer
	//Nothing is needed for define a transformer
	
	public static int turbineNum = 0;
	public static int turbineNumLimit = 1000;

	//0: Turbine; 1: transfomrer; 2: pump
	public enum createType {turbine, transformer, pump} ;

	public createType currentType;


	// Use this for initialization
	void Start () {
		creating = false;
		turbineNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createTurbine(Transform newObject, Quaternion newRotation, int maxOutput, int directionIndex, int cost, Transform button, float time, Color turbineColor){

		currentButton = button;
		currentButton.GetComponent<WindTurbineBtnInfo> ().creating = true;
		WindTurbineBtnInfo.anyButtonCreate = true;
		creating = true;
		currentType = createType.turbine;
		newTransform = newObject;
		rotation = newRotation;

		this.maxOutput = maxOutput;
		this.directionIndex = directionIndex;
		this.cost = cost;
		this.timeForWork = time;
		this.turbineColor = turbineColor;

	}

	public void finishCreateTurbine()
	{
		creating = false;
		WindTurbineBtnInfo.anyButtonCreate = false;
		currentButton.GetComponent<WindTurbineBtnInfo> ().creating = false;
	}

	//Not well defined
	public void createTransformer(Transform newObject, Quaternion newRotation, int cost, Transform button){
		
		creating = true;
		currentType = createType.transformer;
		newTransform = newObject;
		rotation = newRotation;

		this.cost = cost;
	}

	//Not well defined
	public void createPump(Transform newObject, Quaternion newRotation, float pumpTimeBetween, int cost, Transform button){
		
		creating = true;
		currentType = createType.pump;
		newTransform = newObject;
		rotation = newRotation;
		
		this.pumpTimeBetween = pumpTimeBetween;
		this.cost = cost;
		
	}

}
