using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TransformerInfo : InfoItem
{
	
	public int power = 0;
	public int cost = 0;

	public int x;
	public int z;

	public bool powerShow;
	public AudioClip click;

	void Start(){
	
		powerShow = false;
	
	}

	void Update(){
		
		if (powerShow) {
			
			transform.GetChild (1).GetChild (0).GetComponent<Text> ().text = power + " kW";
			
		} 
		else {
			
			transform.GetChild (1).GetChild (0).GetComponent<Text> ().text = "";
			
		}
		
	}

    public override string GetInfo()
    {
		return "Transformer\n\n\n\n" + "Received Power: " + power;
    }

	void OnMouseDown()
	{
		AudioSource.PlayClipAtPoint (click, Camera.main.transform.position);
		GameObject.FindGameObjectWithTag ("screens").GetComponent<CustomizationSwitch> ().toSelectionP ();
		GameObject.FindGameObjectWithTag ("selectionPanel").GetComponent<InfoPanel> ().UpdateInfo (gameObject.transform.GetComponent<TransformerInfo>());
		Debug.Log(GetInfo ());

		if (!powerShow) {
			
			powerShow = true;
			
		} 
		else {
			
			powerShow = false;
			
		}
	}


}
