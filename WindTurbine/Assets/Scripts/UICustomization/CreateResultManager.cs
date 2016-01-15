using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateResultManager : MonoBehaviour {
	
	public int maxOutput;
	public int directionIndex;
	public int cost;
	
	public int baseOutput;
	public int baseCost;
	
	public int extraOutputBlade;
	public int extraCostBlade;
	
	public int extraOutputPowertrain;
	public int extraCostPowertrain;

	public float timeForWork;
	public float baseTimeForWork;

	public string bladeName;
	public string powertrainName;
	
	// Use this for initialization
	void Start () {
		baseOutput = 150;
		baseCost = 150;
		
		maxOutput = baseOutput;
		cost = baseCost;
		baseTimeForWork = 30f;

		timeForWork = baseTimeForWork;
		bladeName = "X";
		powertrainName = "X";
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetChild (1).GetComponent<Text> ().text = " Power Output: " + maxOutput;
		transform.GetChild (2).GetComponent<Text> ().text = " Cost: " + cost + " TC";
		transform.GetChild (3).GetComponent<Text> ().text = " Time Before Repair: " + timeForWork + " s";
	}
	
	public void updateBlade(int extraOutput, int extraCost, string name){
		
		extraOutputBlade = extraOutput;
		extraCostBlade = extraCost;
		
		maxOutput = baseOutput + extraOutputBlade + extraOutputPowertrain;
		cost = baseCost + extraCostBlade + extraCostPowertrain;

		bladeName = name;
	}
	
	public void updatePowertrain(int extraOutput, int extraCost, float time, string name){
		extraOutputPowertrain = extraOutput;
		extraCostPowertrain = extraCost;
		
		maxOutput = baseOutput + extraOutputBlade + extraOutputPowertrain;
		cost = baseCost + extraCostBlade + extraCostPowertrain;

		timeForWork = baseTimeForWork + time;
		powertrainName = name;
	}
}
