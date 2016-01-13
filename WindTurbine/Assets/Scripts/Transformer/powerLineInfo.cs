using UnityEngine;
using System.Collections;

public class powerLineInfo : MonoBehaviour {

	LineRenderer lineRenderer;
	public float loss;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void drawLine(Color color, Vector3 start, Vector3 end, float loss){
		
		lineRenderer = gameObject.GetComponent<LineRenderer> ();
		//lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetWidth (3f, 3f);
		lineRenderer.SetColors(color, color);
		lineRenderer.SetPosition (0, start);
		lineRenderer.SetPosition (1, end);
		
	}
	
	public void drawLine(Color color, Vector3 start, Vector3 end){
		
		Vector2 startGrid = new Vector2 ((int)(start.x + 95) / 10, (int)(95 - start.z) / 10);
		Vector2 endGrid = new Vector2 ((int)(end.x + 95) / 10, (int)(95 - end.z) / 10);
		
		float distance = Vector2.Distance (startGrid, endGrid);
		//		Debug.Log ("start Grid: " + startGrid);
		//		Debug.Log ("end Grid: " + endGrid);
		loss = 1f / Mathf.Sqrt (distance);
		
		lineRenderer = gameObject.GetComponent<LineRenderer> ();
		
		if(Application.loadedLevelName == "Level1" || Application.loadedLevelName == "Level1_1"|| Application.loadedLevelName == "Level1_2"|| Application.loadedLevelName == "Level1_3")
			lineRenderer.SetWidth (5f, 5f);
		else
			lineRenderer.SetWidth (5f, 5f * loss);
		
		lineRenderer.SetColors(color, color);
		lineRenderer.SetPosition (0, start);
		lineRenderer.SetPosition (1, end);
		
	}
	
	public static float length(Vector3 start, Vector3 end)
	{
		Vector2 startGrid = new Vector2 ((int)(start.x + 95) / 10, (int)(95 - start.z) / 10);
		Vector2 endGrid = new Vector2 ((int)(end.x + 95) / 10, (int)(95 - end.z) / 10);
		
		float distance = Vector2.Distance (startGrid, endGrid);
		
		return distance;
	}
}
