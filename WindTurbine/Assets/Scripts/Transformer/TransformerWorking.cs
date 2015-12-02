using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransformerWorking : MonoBehaviour {

	public Transform pump;
	public List<Transform> turbineLinks = new List<Transform>();

	public bool enabled;

	// Use this for initialization
	void Start () {

		enabled = false;

		pump = GameObject.FindGameObjectWithTag("waterTower").transform;
		//linkToWaterTower (pump);
	}
	
	// Update is called once per frame
	void Update () {

		if (turbineLinks.Count <= 0)
			enabled = false;

	}

	public void linkToWaterTower(Transform target)
	{

		if (enabled && target.CompareTag("waterTower")) {

			GameObject newGameObject = new GameObject();
			newGameObject.transform.SetParent(gameObject.transform);
			newGameObject.transform.localPosition = Vector3.zero;
			
			LineRenderer lineRenderer = newGameObject.AddComponent<LineRenderer>();
			lineRenderer.SetWidth(0.5f, 0.5f);
			lineRenderer.SetPosition(0, newGameObject.transform.position);
			lineRenderer.SetPosition(1, target.position);
			
			target.GetChild(1).GetComponent<PumpAttacking>().enableWork();
			
		}
	}

	public void linkToWaterTower()
	{

		pump = GameObject.FindGameObjectWithTag("waterTower").transform;

		if (enabled && pump.CompareTag("waterTower")) {
			
			GameObject newGameObject = new GameObject();
			newGameObject.transform.SetParent(gameObject.transform);
			newGameObject.transform.localPosition = Vector3.zero;
			
			LineRenderer lineRenderer = newGameObject.AddComponent<LineRenderer>();
			lineRenderer.SetWidth(0.5f, 0.5f);
			lineRenderer.SetPosition(0, newGameObject.transform.position);
			lineRenderer.SetPosition(1, pump.position);
			
			pump.GetChild(1).GetComponent<PumpAttacking>().enableWork();
			
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
