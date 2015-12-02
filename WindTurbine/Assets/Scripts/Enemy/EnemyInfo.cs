using UnityEngine;
using System.Collections;

public class EnemyInfo : InfoItem {
	
	public int waterAmount = 1;	//Current water amount(HP)
	public int speed = 10;		//Speed per unit (units per second)
	public int rewards = 1;	//coins that will provide
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public override string GetInfo()
    {
        return "Water Amount: " + waterAmount + "\nSpeed: " + speed + "\nReward: " + rewards;
    }
}
