using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PumpAttacking : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackingDamage;
	public bool isWorking;
	public int attackingGridRadius = 4;

	private List<Transform> attackingList = new List<Transform>();
	private float timer;

	private Transform currentTarget;
	private EnemyHealth currentEnemyHealth;


	// Use this for initialization
	void Start () {

		//isWorking = false;

		timeBetweenAttacks = gameObject.GetComponentInParent<PumpInfo> ().pumpTimeBetween;
		//attackingDamage = gameObject.GetComponentInParent<PumpInfo> ().pumpDamage;
		attackingDamage = gameObject.GetComponentInParent<PumpInfo> ().currentPower;

		if (isWorking)
			enableWork ();
		else
			disableWork ();

		gameObject.transform.localScale = new Vector3 (attackingGridRadius * 20, 40, attackingGridRadius * 20);

		timer = 0f;
		attackingDamage = 10;
	}
	
	// Update is called once per frame
	void Update () {

		attackingDamage = gameObject.GetComponentInParent<PumpInfo> ().pumpDamage;

		if (isWorking) {
		
			timer += Time.deltaTime;
			
			if (timer >= timeBetweenAttacks) {
				attack ();
			}
		
		} else {
		
			disableWork();
			timer = 0f;
		}

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("waterDrop")) {
			attackingList.Add(other.gameObject.transform);
			//Debug.Log ("Enter: " + attackingList.Count);
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("waterDrop")) {
			other.gameObject.GetComponent<EnemyHealth>().attacked = false;
			other.gameObject.transform.localScale = new Vector3(7.152498f, 7.055891f, 7.152498f);
			attackingList.Remove(other.gameObject.transform);
			//Debug.Log ("Exit: " + attackingList.Count);
		}
	}

	void attack(){
		timer = 0f;

		if (attackingList.Count <= 0)
			return;
		else {
		
			for (int i = 0; i< attackingList.Count; i++) {
				
				if(attackingList [i]==null){
					attackingList.RemoveAt(i);
					i = i-1;
				}else{

					currentTarget = attackingList [i].transform;
					break;

				}
			}
		
		}
			//currentTarget = attackingList [0].transform;

//		for (int i = 0; i< attackingList.Count; i++) {
//
//			if(currentTarget.GetComponent<EnemyHealth>().health > attackingList [i].transform.GetComponent<EnemyHealth>().health)
//				currentTarget = attackingList [i].transform;
//
//		}

		if (currentTarget == null)
			return;

		currentEnemyHealth = currentTarget.GetComponent<EnemyHealth> ();

		if(currentEnemyHealth.health<=attackingDamage)
		{
			attackingList.Remove (currentTarget);
			currentEnemyHealth.attack(attackingDamage);
		}
		
		else
			currentEnemyHealth.attack(attackingDamage);
	}

	public void enableWork()
	{
		Debug.Log ("working");
		//what???
		isWorking = true;
		Color color = gameObject.GetComponent<MeshRenderer> ().material.color;
		color.a = 70f/255f;
		gameObject.GetComponent<MeshRenderer> ().material.color = color;
	}

	public void disableWork(){

		isWorking = false;
		Color color = gameObject.GetComponent<MeshRenderer> ().material.color;
		color.a = 0f;
		gameObject.GetComponent<MeshRenderer> ().material.color = color;

	}
}
