using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
    public GameObject p;
	// Use this for initialization
	public void Close () {
        p.SetActive(false);
	}
	

}
