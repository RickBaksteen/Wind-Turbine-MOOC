using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health;
	public int maxHealth = 50;
	private Vector3 slider;

	// Use this for initialization
	void Start () {

		if (Application.loadedLevelName == "Level4")
			maxHealth = 60;

		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0)
			die ();

		slider = new Vector3 ((float)health / (float) maxHealth, 1, 1);
		gameObject.transform.GetChild (2).transform.GetChild (2).transform.GetComponent<RectTransform> ().localScale = slider;

	}

	public void attack(int damage){
		health -= damage;
	}

	public void die(){
        GameObject.FindGameObjectWithTag("enemyManager").transform.GetComponent<EnemyManager>().rainAmount -= gameObject.transform.GetComponent<EnemyInfo>().waterAmount;
		MoneyManager.money += gameObject.transform.GetComponent<EnemyInfo>().rewards;
		Destroy (gameObject);
        KilledDrops.killedDrops += 1;
	}
}
