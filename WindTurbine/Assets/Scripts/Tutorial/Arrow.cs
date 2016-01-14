using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    public GameObject p1;
    public GameObject p2;

	// Use this for initialization
	void Start () {
        this.transform.position = (p1.transform.position + p2.transform.position) /2;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = (p1.transform.position + p2.transform.position) / 2;
    }
}
