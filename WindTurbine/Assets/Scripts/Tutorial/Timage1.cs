using UnityEngine;
using System.Collections;

public class Timage1 : MonoBehaviour {

    public GameObject p;
    

	// Use this for initialization
	void Start () {
        this.transform.position = p.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = p.transform.position;
    }
}
