using UnityEngine;
using System.Collections;

public class WindTurbineBtnInfo : MonoBehaviour {

	public Transform windTurbine;
	public Quaternion rotation;

	public int maxOutput;
	public int directionIndex;

	// Use this for initialization
	void Start () {
		rotation = new Quaternion (-0.5f, -0.5f, -0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void createTurbine(){

		GameObject.FindGameObjectWithTag ("createManager").GetComponent<CreateManager> ().createTransform (windTurbine, rotation, maxOutput,directionIndex);

	}
}
