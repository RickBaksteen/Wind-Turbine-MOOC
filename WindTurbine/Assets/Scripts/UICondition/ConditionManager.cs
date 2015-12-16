using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConditionManager : MonoBehaviour {

	//public string[] conditions = {"Normal", "Normal", "Normal", "Normal", "Normal", "Earthquake!!", "Storm!!"};
	public string[] conditions = {"Normal", "Normal", "Normal", "Normal", "Normal"};

	public int conditionIndex = 0;
	public float conditionChangeTimeBetween = 5f;

	private float timer;

	// Use this for initialization
	void Start () {
		changeCondition ();
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (timer >= conditionChangeTimeBetween) {
			changeCondition();
			timer -= conditionChangeTimeBetween;
		}
	
	}

	void changeCondition(){

		conditionIndex = Random.Range(0, conditions.Length);
		gameObject.transform.GetChild(0).GetComponent<Text>().text = conditions[conditionIndex];

	}
}
