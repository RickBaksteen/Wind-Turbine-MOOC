using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

	public static int money = 1000;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.GetChild (0).GetComponent<Text> ().text = "  Money: " + money + " TC";

	}
}
