using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health;

	// Use this for initialization
	void Start () {
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0)
			die ();

	}

	public void attack(int damage){
		health -= damage;
	}

	public void die(){
		Destroy (gameObject);
	}
}
