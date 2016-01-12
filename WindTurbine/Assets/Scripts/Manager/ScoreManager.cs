using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static int score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		score = MoneyManager.money;

		if (Application.loadedLevelName != "Win" || Application.loadedLevelName != "Fail") {
		
			GameObject[] Turbines = GameObject.FindGameObjectsWithTag("turbine");

			for(int i = 0; i < Turbines.Length; i++){
				score += Turbines[i].transform.GetComponent<TurbineInfo>().cost;
			}
		}
		if (Application.loadedLevelName == "Fail")
			score = 0;
	}
}
