using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WindManager : MonoBehaviour {

	public string[] windDirection = {"N", "NE", "E", "SE", "S", "SW", "W", "NW"};
	public int windIndex = 0;
	public float windChangeTimeBetween = 5f;

	private float timer;


	// Use this for initialization
	void Start () {
		ChangeWind ();
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (timer >= windChangeTimeBetween) {
			ChangeWind();
			timer -= windChangeTimeBetween;
		}
	
	}

	void ChangeWind(){

		windIndex = Random.Range(0, windDirection.Length);
		//Debug.Log ("WindDirection: " + windIndex);

		gameObject.transform.GetChild(0).GetComponent<Text>().text = "  Wind: " + windDirection[windIndex];
	
	}

}
