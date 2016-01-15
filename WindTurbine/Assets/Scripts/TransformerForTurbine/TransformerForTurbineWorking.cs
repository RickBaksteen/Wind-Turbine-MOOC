using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransformerForTurbineWorking : MonoBehaviour {

	public Transform pump;
	public List<Transform> turbineLinks = new List<Transform> ();
	public bool enabled;
	
	public Transform powerLine;

	public Transform poweredTransformer;

	public int previousPower;
	
	// Use this for initialization
	void Start () {
		
		enabled = false;
		linkToTransformer ();
		previousPower = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (turbineLinks.Count <= 0)
			enabled = false;
		
		gameObject.GetComponent<TransformerForTurbineInfo>().originalPower = 0;
		
		foreach (Transform turbine in turbineLinks){
			gameObject.GetComponent<TransformerForTurbineInfo>().originalPower += turbine.GetComponent<TurbineInfo>().output;
		}

		poweredTransformer.GetComponent<TransformerInfo> ().power = gameObject.GetComponent<TransformerForTurbineInfo>().outputPower;
		
	}
	
	public void linkTurbine(Transform target){
		
		if (target.CompareTag("turbine")) {
			
			enabled = true;
			turbineLinks.Add(target);
			//target.GetComponent<TurbineInfo>().calculatePowerLoss();
			transform.GetComponent<TransformerForTurbineInfo> ().showNewPower (turbineLinks[turbineLinks.Count-1]);
		}
		
	}


	
	public void unlinkTurbine(Transform target){
		
		if (target.CompareTag("turbine")) {
			
			turbineLinks.Remove(target);
			
		}
		
	}

	public void linkToTransformer()
	{

		poweredTransformer = GameObject.FindGameObjectWithTag ("transformer").transform;

		Transform newLine = (Transform) Instantiate(powerLine, gameObject.transform.position, Quaternion.identity);
		newLine.SetParent(gameObject.transform);
		newLine.localPosition = Vector3.zero;

		if(Application.loadedLevelName=="Level1_1"||Application.loadedLevelName=="Level1_2")
			newLine.GetComponent<powerLineInfo>().drawLine(new Color(0f, 0f, 1f, 1f), gameObject.transform.position, poweredTransformer.position, 1f);
		else
			newLine.GetComponent<powerLineInfo>().drawLine(new Color(0f, 0f, 1f, 1f), gameObject.transform.position, poweredTransformer.position, 1f);

	}
}
