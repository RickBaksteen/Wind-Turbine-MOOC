using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WindCustomizationPanelInfo : MonoBehaviour {

    public GameObject TurbPrefab;
	public int newturbineCount;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void Instantiate()
    {
        //create a new item, name it, and set the parent
        GameObject newItem = Instantiate(TurbPrefab);
        newItem.transform.SetParent(TurbPrefab.transform.parent, false);
        newItem.GetComponent<WindTurbineBtnInfo>().maxOutput=GameObject.FindGameObjectWithTag("createResultHolder").GetComponent<CreateResultManager>().maxOutput;
		newItem.GetComponent<WindTurbineBtnInfo>().cost=GameObject.FindGameObjectWithTag("createResultHolder").GetComponent<CreateResultManager>().cost;
		newturbineCount++;
		newItem.transform.GetChild (0).GetComponent<Text> ().text = "Custom " + newturbineCount;

        //move and size the new item
        RectTransform rectTransform = newItem.GetComponent<RectTransform>();
    }
}
