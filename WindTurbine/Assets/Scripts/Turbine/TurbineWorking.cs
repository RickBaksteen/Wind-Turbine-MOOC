using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurbineWorking : MonoBehaviour {

	public List<Transform> transformers = new List<Transform>();
	public Transform transformerForTurbine;
	public Transform powerLine;


	// Use this for initialization
	void Start () {
		
		transformerForTurbine = GameObject.FindGameObjectWithTag("transformerForTurbine").transform;
		linkToTransformer (transformerForTurbine);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void linkToTransformer(Transform target){

		Color powerLineColor = new Color (1f, 0f, 0f, 1f);
		
		if(Application.loadedLevelName=="Level1_1"||Application.loadedLevelName=="Level1_2")
			powerLineColor = new Color (0f, 0f, 1f, 1f);
		else
			powerLineColor = new Color (1f, 0f, 0f, 1f);

		if (target.CompareTag ("transformerForTurbine")) {
			
			transformers.Add(target);
			target.transform.GetComponent<TransformerForTurbineWorking>().linkTurbine(gameObject.transform);
			
			//target.GetComponent<TransformerWorking>().linkToWaterTower();
			
			//			GameObject newGameObject = new GameObject();
			//			newGameObject.transform.SetParent(gameObject.transform);
			//			newGameObject.transform.localPosition = Vector3.zero;
			//
			//			LineRenderer lineRenderer = newGameObject.AddComponent<LineRenderer>();
			//			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			//			lineRenderer.SetWidth(0.5f, 0.5f);
			//			lineRenderer.SetPosition(0, newGameObject.transform.position);
			//			lineRenderer.SetPosition(1, target.position);
			
			Transform newLine = (Transform) Instantiate(powerLine, gameObject.transform.position, Quaternion.identity);
			newLine.SetParent(gameObject.transform);
			newLine.localPosition = Vector3.zero;
			newLine.GetComponent<powerLineInfo>().drawLine(powerLineColor, gameObject.transform.position, target.position);
			
		}
		
	}
	
	public void unlinkToTransformer(Transform target){
		
		if (target.CompareTag ("transformerForTurbine")) {
			
			int index = transformers.IndexOf(target);
			
			Transform newGameObject = gameObject.transform.GetChild(index+1);
			Destroy(newGameObject.gameObject);
			transformers.Remove(target);
			
			LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
			Destroy(lineRenderer.gameObject); //I don't know whether this would work or not.
			target.transform.GetComponent<TransformerForTurbineWorking>().unlinkTurbine(gameObject.transform);
		}
		
	}
}
