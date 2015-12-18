using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WindCustomizationPanelInfo : MonoBehaviour {

    public GameObject TurbPrefab;

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
        newItem.GetComponent<WindTurbineBtnInfo>().maxOutput=150;

        //move and size the new item
        RectTransform rectTransform = newItem.GetComponent<RectTransform>();
    }
}
