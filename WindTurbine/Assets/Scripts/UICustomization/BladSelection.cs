using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BladSelection : MonoBehaviour, IPointerClickHandler {

	public int output;
	public int cost;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
//			transform.GetComponent<Button>().interactable = false;
			GameObject.FindGameObjectWithTag("createResultHolder").GetComponent<CreateResultManager>().updateBlade(output, cost);
		} else if (eventData.button == PointerEventData.InputButton.Middle) {
			//			Debug.Log ("Middle click");
		} else if (eventData.button == PointerEventData.InputButton.Right) {
			//			Debug.Log ("Right click");
		}
	}
}
