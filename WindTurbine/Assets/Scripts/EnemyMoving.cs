using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMoving : MonoBehaviour {
	
	public List<Transform> routeTurningPoints = new List<Transform>();
	public Transform target;
	public float speed = 10;

	private int i;


	// Use this for initialization
	void Start () {

		Transform turningPointsObject = GameObject.FindGameObjectWithTag ("routeTurningPoints").transform;
		Transform bufferPoint;
		i = 0;

		while (i < turningPointsObject.childCount) {
			routeTurningPoints.Add (turningPointsObject.GetChild (i).transform);
			i++;
		}

		i = 0;
		target = routeTurningPoints [i];
		
	}
	
	// Update is called once per frame
	void Update () {

		if (target == null)
			return;

		if (i >= routeTurningPoints.Count)
			return;

		if (Mathf.Abs(transform.position.x - target.position.x) <=  5 && Mathf.Abs(transform.position.z - target.position.z) <=  5) {
			i++;

			if (i == routeTurningPoints.Count){

				WaterCountManager.waterCount++;
				Destroy(gameObject);
				Debug.Log(WaterCountManager.waterCount);
				return;
			}

			target = routeTurningPoints[i];
			return;
		}

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
