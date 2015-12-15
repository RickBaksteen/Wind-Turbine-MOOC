using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyCountManager : MonoBehaviour {

	public int enemyBound = 10;
	public int polluted;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		polluted = WaterCountManager.waterCount;

//		if (polluted >= enemyBound) {
//			Time.timeScale = 0;
//		}

		showEnemyCount ();
	}

	public void showEnemyCount(){
		transform.GetChild (0).GetComponent<Text> ().text = "  Flood: " + polluted + " / " + enemyBound;
	}
}
