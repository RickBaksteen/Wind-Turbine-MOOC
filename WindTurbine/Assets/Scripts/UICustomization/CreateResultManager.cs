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
	
	// Use this for initialization
	void Start () {
		baseOutput = 150;
		baseCost = 150;
		
		maxOutput = baseOutput;
		cost = baseCost;
		baseTimeForWork = 30f;

		timeForWork = baseTimeForWork;
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetChild (1).GetComponent<Text> ().text = "\t\t  Power: " + maxOutput;
		transform.GetChild (2).GetComponent<Text> ().text = "\t\t  Cost: " + cost + " TC";
		transform.GetChild (3).GetComponent<Text> ().text = "\t\t  Working Time: " + timeForWork + " s";
	}
	
	public void updateBlade(int extraOutput, int extraCost){
		
		extraOutputBlade = extraOutput;
		extraCostBlade = extraCost;
		
		maxOutput = baseOutput + extraOutputBlade + extraOutputPowertrain;
		cost = baseCost + extraCostBlade + extraCostPowertrain;
	}
	
	public void updatePowertrain(int extraOutput, int extraCost, float time){
		extraOutputPowertrain = extraOutput;
		extraCostPowertrain = extraCost;
		
		maxOutput = baseOutput + extraOutputBlade + extraOutputPowertrain;
		cost = baseCost + extraCostBlade + extraCostPowertrain;

		timeForWork = baseTimeForWork + time;
	}
}
