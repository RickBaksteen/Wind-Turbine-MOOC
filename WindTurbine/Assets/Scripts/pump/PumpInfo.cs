using UnityEngine;
using System.Collections;
using System;

public class PumpInfo : MonoBehaviour {

	public float pumpTimeBetween= 0.5f;		//pump rate(atk speed)
	public int pumpDamage = 10;	//pump damage;
	public int currentPower;	//Current Power(used to calculate AS,DMG)???
	public float percentage = 0.47f;	//Current power to Percentage of cap (example 47% to 100%)
	public int maxPower = 20;		//Max Power

	// Use this for initialization
	void Start () {

		Transform turbine = GameObject.FindGameObjectWithTag ("turbine").transform;

		int distance = (int) Math.Abs (turbine.position.x - transform.position.x) + (int) Math.Abs (turbine.position.z - transform.position.z);
		distance /= 10;

		if (distance > 10)
			percentage = 0.47f;
		else
			percentage = (float)((distance - 10) * ((1 - 0.47f) / (1 - 10))) + 0.47f;
	
		currentPower = (int)(maxPower * percentage);

	}
	
	// Update is called once per frame
	void Update () {
		//currentPower = (int)(maxPower * percentage);
	}
}
