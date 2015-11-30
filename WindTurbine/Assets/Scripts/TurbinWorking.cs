using UnityEngine;
using System.Collections;

public class TurbinWorking : MonoBehaviour {


	public int influenceGridRadius = 4;


	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = new Vector3 (influenceGridRadius * 2000, influenceGridRadius * 2000, 500);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("waterTower")) {
			other.gameObject.transform.GetChild(1).GetComponent<PumpAttacking>().enableWork();
		}

	}
}
