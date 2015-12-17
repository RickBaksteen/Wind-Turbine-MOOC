using UnityEngine;
using System.Collections;

public class CreateManager : MonoBehaviour {

	public bool creating;
	public Transform newTransform;
	public Quaternion rotation;

	//Parameter for Turbine
	public int maxOutput;
	public int directionIndex;
	public int cost;

	//Parameter for Pump
	public float pumpTimeBetween;

	//Parameter for Transformer
	//Nothing is needed for define a transformer
	
	public static int turbineNum = 0;
	public static int turbineNumLimit = 2;

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

	public void createTurbine(Transform newObject, Quaternion newRotation, int maxOutput, int directionIndex, int cost){

		creating = true;
		currentType = createType.turbine;
		newTransform = newObject;
		rotation = newRotation;

		this.maxOutput = maxOutput;
		this.directionIndex = directionIndex;
		this.cost = cost;

	}

	//Not well defined
	public void createTransformer(Transform newObject, Quaternion newRotation){
		
		creating = true;
		currentType = createType.transformer;
		newTransform = newObject;
		rotation = newRotation;
		
	}

	//Not well defined
	public void createPump(Transform newObject, Quaternion newRotation, float pumpTimeBetween){
		
		creating = true;
		currentType = createType.pump;
		newTransform = newObject;
		rotation = newRotation;
		
		this.pumpTimeBetween = pumpTimeBetween;
		
	}

}
