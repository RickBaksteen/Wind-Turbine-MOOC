using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health;
	private Vector3 slider;

	// Use this for initialization
	void Start () {
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0)
			die ();

		slider = new Vector3 ((float)health / 100f, 1, 1);
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
