using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TransformerWorking : MonoBehaviour {

	public Transform pump;
	public List<Transform> turbineLinks = new List<Transform> ();
	public List<Transform> pumpLinks = new List<Transform> ();
	public bool enabled;

	public Transform powerLine;

	public float lossK;

	// Use this for initialization
	void Start () {
		
		enabled = false;
		lossK = 0.0005f;
		
		//pump = GameObject.FindGameObjectWithTag("waterTower").transform;
		//pumpLinks.Add (pump);
		//linkToWaterTower (pump);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (turbineLinks.Count <= 0)
			enabled = false;
		
		foreach (Transform pump in pumpLinks) {
			
			int originalPower = gameObject.GetComponent<TransformerInfo>().power/pumpLinks.Count;
			int powerLoss;
			
			if (Application.loadedLevelName == "Level1" || Application.loadedLevelName == "Level1_1"|| Application.loadedLevelName == "Level1_2"|| Application.loadedLevelName == "Level1_3")
				powerLoss = 0;
			else
				powerLoss = (int)(lossK * originalPower * originalPower * powerLineInfo.length(transform.position, pump.position));
			
			
			pump.GetComponent<PumpInfo>().power = Math.Max(originalPower - powerLoss, 0);
		}
		
	}
	
	//Here is where it is invoking now.
	public void linkToWaterTower(Transform target)
	{
		Color powerLineColor = new Color (1f, 0f, 0f, 1f);

		if(Application.loadedLevelName=="Level1_1"||Application.loadedLevelName=="Level1_2")
			powerLineColor = new Color (0f, 0f, 1f, 1f);
		else
			powerLineColor = new Color (1f, 0f, 0f, 1f);



		if (target.CompareTag("waterTower")) {
			
			//			GameObject newGameObject = new GameObject();
			//			newGameObject.name = "line";
			//			newGameObject.transform.SetParent(gameObject.transform);
			//			newGameObject.transform.localPosition = Vector3.zero;
			//			
			//			LineRenderer lineRenderer = newGameObject.AddComponent<LineRenderer>();
			//			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			//			lineRenderer.SetWidth(0.5f, 0.5f);
			//			lineRenderer.SetPosition(0, newGameObject.transform.position);
			//			lineRenderer.SetPosition(1, target.position);
			
			pumpLinks.Add(target);
			Transform newLine = (Transform) Instantiate(powerLine, gameObject.transform.position, Quaternion.identity);
			newLine.SetParent(gameObject.transform);
			newLine.localPosition = Vector3.zero;
			newLine.GetComponent<powerLineInfo>().drawLine(powerLineColor, gameObject.transform.position, target.position);
			
			target.GetChild(1).GetComponent<PumpAttacking>().enableWork();
		}
	}
	
	public void linkToWaterTower()
	{
		
		Debug.Log ("Connected");
		pump = GameObject.FindGameObjectWithTag("waterTower").transform;
		
		if (pump.CompareTag("waterTower")) {
			
			//			GameObject newGameObject = new GameObject();
			//			newGameObject.name = "line";
			//			newGameObject.transform.SetParent(gameObject.transform);
			//			newGameObject.transform.localPosition = Vector3.zero;
			//
			//			LineRenderer lineRenderer = newGameObject.AddComponent<LineRenderer>();
			//			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			//			lineRenderer.SetWidth(0.5f, 0.5f);
			//			lineRenderer.SetPosition(0, newGameObject.transform.position);
			//			lineRenderer.SetPosition(1, pump.position);
			
			Transform newLine = (Transform) Instantiate(powerLine, gameObject.transform.position, Quaternion.identity);
			newLine.SetParent(gameObject.transform);
			newLine.localPosition = Vector3.zero;
			newLine.GetComponent<powerLineInfo>().drawLine(new Color(1f, 1f, 0f, 1f), gameObject.transform.position, pump.position, 1f);
			
			pump.GetChild(1).GetComponent<PumpAttacking>().enableWork();
		}
	}
	
	public void unLinkToWaterTower(Transform target)
	{
		int index = pumpLinks.IndexOf(target);
		
		if (target.CompareTag("waterTower")) {
			
			enabled = true;
			pumpLinks.Remove(target);
			
			GameObject line = gameObject.transform.GetChild(index+1).gameObject;
			
			GameObject.Destroy(line);
			
		}
	}
	
	public void linkTurbine(Transform target){
		
		if (target.CompareTag("turbine")) {
			
			enabled = true;
			turbineLinks.Add(target);
			
		}
		
	}
	
	public void unlinkTurbine(Transform target){
		
		if (target.CompareTag("turbine")) {
			
			turbineLinks.Remove(target);
			
		}
		
	}

}
