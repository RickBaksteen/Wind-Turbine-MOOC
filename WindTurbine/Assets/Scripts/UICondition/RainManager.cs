using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class RainManager : MonoBehaviour {

	int rainAmount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rainAmount = GameObject.FindGameObjectWithTag ("enemyManager").transform.GetComponent<EnemyManager> ().rainAmount;
		gameObject.transform.GetChild(0).GetComponent<Text>().text = " Excess Water: " + rainAmount;
	}
}
