using UnityEngine;
using System.Collections;

public class TransformerInfo : InfoItem
{
	
	public int power;

    public override string GetInfo()
    {
        return "Power: " + power;
    }

	void OnMouseDown(){
		Debug.Log (GetInfo ());
	}
}
