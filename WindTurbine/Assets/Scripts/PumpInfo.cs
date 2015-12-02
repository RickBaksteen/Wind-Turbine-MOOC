using UnityEngine;
using System.Collections;

public class PumpInfo : MonoBehaviour {

	int pumpRate = 10;		//pump rate(atk speed)
	int pumpDamage = 10;	//pump damage;
	int currentPower = 10;	//Current Power(used to calculate AS,DMG)???
	int percentage = 47;	//Current power to Percentage of cap (example 47% to 100%)
	int maxPower = 100;		//Max Power

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
