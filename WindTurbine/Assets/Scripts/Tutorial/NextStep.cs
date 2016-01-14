using UnityEngine;
using System.Collections;

public class NextStep : MonoBehaviour {

    public GameObject n;
    public GameObject c;
    
    // Use this for initialization
    public void Click () {
        n.SetActive(true);
        c.SetActive(false);

    }
	
    void Start() { }
  
}
