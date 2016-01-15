using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CustomizationSwitch : MonoBehaviour {

	public GameObject panelC;
	public GameObject panelS;

	public void Start(){
	
		toSelectionP ();
	
	}
	
	public void toCustomizationP()
	{
		panelC.SetActive(true);
		panelS.SetActive(false);
	}
	public void toSelectionP()
	{
		Debug.Log ("toSelectionP");
		panelS.SetActive(true);
		panelC.SetActive(false);

	}
}
