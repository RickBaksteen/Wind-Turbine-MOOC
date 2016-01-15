using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMoving : MonoBehaviour {
	
	public List<Transform> routeTurningPoints = new List<Transform>();
	public Transform target;
	public float speed = 10;
	public AudioClip flood;

	private int i;
	private Transform waterPool;


	// Use this for initialization
	void Start () {

		Transform turningPointsObject = GameObject.FindGameObjectWithTag ("routeTurningPoints").transform;
		Transform bufferPoint;
		waterPool = GameObject.FindGameObjectWithTag ("waterPool").transform;
		waterPool.localScale = new Vector3(38.0f, 1.0f, 38.0f);
		waterPool.localPosition = new Vector3(-155.0f, (-20.1f + (((float)WaterCountManager.waterCount/10.0f)*(20.1f-7.5f))), 40.0f);

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

		if (Mathf.Abs(transform.position.x - target.position.x) <=  0.1 && Mathf.Abs(transform.position.z - target.position.z) <=  0.1) {
			i++;

			if (i == routeTurningPoints.Count){
				AudioSource.PlayClipAtPoint(flood, Camera.main.transform.position, 0.7f);
				WaterCountManager.waterCount++;
				waterPool.localPosition = new Vector3(-155.0f, (-20.1f + (((float)WaterCountManager.waterCount/10.0f)*(20.1f-7.5f))), 40.0f);
				GameObject.FindGameObjectWithTag("enemyManager").transform.GetComponent<EnemyManager>().rainAmount-=gameObject.transform.GetComponent<EnemyInfo>().waterAmount;
				//MoneyManager.money += gameObject.transform.GetComponent<EnemyInfo>().rewards;
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
