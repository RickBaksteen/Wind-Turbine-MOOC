using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurbineWorking : MonoBehaviour {


	public int influenceGridRadius = 4;
	public List<Transform> transformers = new List<Transform>();
	public Transform transformer;


	// Use this for initialization
	void Start () {
		//gameObject.transform.localScale = new Vector3 (influenceGridRadius * 2000, influenceGridRadius * 2000, 500);

		transformer = GameObject.FindGameObjectWithTag("transformer").transform;
		linkToTransformer (transformer);

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void linkToTransformer(Transform target){

		if (target.CompareTag ("transformer")) {

			transformers.Add(target);
			target.transform.GetComponent<TransformerWorking>().linkTurbine(gameObject.transform);

			target.GetComponent<TransformerWorking>().linkToWaterTower();

			GameObject newGameObject = new GameObject();
			newGameObject.transform.SetParent(gameObject.transform);
			newGameObject.transform.localPosition = Vector3.zero;

			LineRenderer lineRenderer = newGameObject.AddComponent<LineRenderer>();
			lineRenderer.SetWidth(0.5f, 0.5f);
			lineRenderer.SetPosition(0, newGameObject.transform.position);
			lineRenderer.SetPosition(1, target.position);
		}

	}

	public void unlinkToTransformer(Transform target){

		if (target.CompareTag ("transformer")) {
			
			int index = transformers.IndexOf(target);
			
			Transform newGameObject = gameObject.transform.GetChild(index+1);
			Destroy(newGameObject);
			transformers.Remove(target);
		}

	}
}
