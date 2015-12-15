using UnityEngine;
using System.Collections;

public class GameEnd : MonoBehaviour {

    public int allDrops = 30;
   // public int killedDrops = 0;
    

	// Use this for initialization
	void Start () {
   
	}
	
	// Update is called once per frame
	void Update () {
	
        if (WaterCountManager.waterCount == 10)
        {
            Application.LoadLevel("Fail");
        }
       else if ((KilledDrops. killedDrops + WaterCountManager .waterCount ) == allDrops )
        {
            KilledDrops.killedDrops = 0;
            Application.LoadLevel("Win");
        }
       
    }
}
