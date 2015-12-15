using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SellManager : MonoBehaviour {

	public GameObject sellingObject;

	// Use this for initialization
	void Start () {
		gameObject.transform.GetComponent<Button>().interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void sell()
	{
		MoneyManager.money += (int)(sellingObject.transform.GetComponent<TurbineInfo> ().cost * 0.5);
		Transform transformer = sellingObject.transform.GetComponent<TurbineWorking>().transformer;
		transformer.GetComponent<TransformerWorking> ().unlinkTurbine (sellingObject.transform);
		Destroy (sellingObject);
		GameObject.FindGameObjectWithTag("createManager").GetComponent<CreateManager>().turbineNum--;
		gameObject.transform.GetComponent<Button>().interactable = false;
	}

	public void proposeSell(GameObject newGameObject)
	{
		gameObject.transform.GetComponent<Button>().interactable = true;
		sellingObject = newGameObject;
	}
}
