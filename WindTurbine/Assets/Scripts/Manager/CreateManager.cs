using UnityEngine;
using System.Collections;

public class CreateManager : MonoBehaviour {

	public bool creating;
	public Transform newTransform;
	public Quaternion rotation;

	public int maxOutput;
	public int directionIndex;

	// Use this for initialization
	void Start () {
		creating = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createTransform(Transform newObject, Quaternion newRotation, int maxOutput, int directionIndex){

		creating = true;
		newTransform = newObject;
		rotation = newRotation;
		this.maxOutput = maxOutput;
		this.directionIndex = directionIndex;
	}
}
