using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerInfo : MonoBehaviour {
    public int power;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.GetComponent<Text>().text = " Power: " + power;
    }
}
