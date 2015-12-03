using UnityEngine;
using System.Collections;

public class WindTurbineBtnInfo : MonoBehaviour {

	public Transform windTurbine;

	// Use this for initialization
	void Start () {
		windTurbine.GetComponent<TurbineInfo> ().maxOutput = 100;
		windTurbine.GetComponent<TurbineInfo> ().directionIndex = 2;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
