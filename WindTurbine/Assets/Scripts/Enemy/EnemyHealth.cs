using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health;
	public int maxHealth;
	public AudioClip coins;
	public AudioClip pump;
	private Vector3 slider;
	public bool attacked;

	// Use this for initialization
	void Start () {
		attacked = false;
	//	if (Application.loadedLevelName == "Level4")
	//		maxHealth = 120;

		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0)
			die ();

		slider = new Vector3 ((float)health / (float) maxHealth, 1, 1);
		gameObject.transform.GetChild (2).transform.GetChild (2).transform.GetComponent<RectTransform> ().localScale = slider;
		if (attacked) {
			gameObject.transform.localScale = new Vector3(7.152498f + Mathf.Sin (Time.time*4), 7.055891f + Mathf.Sin (Time.time*4), 7.152498f + Mathf.Sin (Time.time*4));
		}


	}

	public void attack(int damage){
		health -= damage;
		if (damage > 0) {
			AudioSource.PlayClipAtPoint (pump, Camera.main.transform.position, 0.1f);
			attacked = true;
		}
	}

	public void die(){
        GameObject.FindGameObjectWithTag("enemyManager").transform.GetComponent<EnemyManager>().rainAmount -= gameObject.transform.GetComponent<EnemyInfo>().waterAmount;
		MoneyManager.money += gameObject.transform.GetComponent<EnemyInfo>().rewards;
		AudioSource.PlayClipAtPoint (coins, Camera.main.transform.position);
		Destroy (gameObject);
        KilledDrops.killedDrops += 1;
	}
}
