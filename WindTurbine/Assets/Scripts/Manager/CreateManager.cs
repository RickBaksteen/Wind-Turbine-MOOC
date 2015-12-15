using UnityEngine;
using System.Collections;

public class CreateManager : MonoBehaviour {

	public bool creating;
	public Transform newTransform;
	public Quaternion rotation;

	public int maxOutput;
	public int directionIndex;
	public int cost;

	public int turbineNum = 0;
	public static int turbineNumLimit = 2;

	// Use this for initialization
	void Start () {
		creating = false;
		turbineNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createTransform(Transform newObject, Quaternion newRotation, int maxOutput, int directionIndex, int cost){

		creating = true;
		newTransform = newObject;
		rotation = newRotation;
		this.maxOutput = maxOutput;
		this.directionIndex = directionIndex;
		this.cost = cost;
	}
}
