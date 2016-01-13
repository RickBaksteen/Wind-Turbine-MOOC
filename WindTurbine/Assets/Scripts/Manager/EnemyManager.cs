using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime = 1f;
	public Transform[] spawnPoints;
	public int spawnLimit;

	public float timeBetweenNextWave = 10f;
	public int waveNum = 3;

	public int rainAmount = 1;

	private int spawnNum = 0;
	public int currentWave = 0;

	private float waveTime;
	//private float waitTime;

	public bool waveComing;

	// Use this for initialization
	void Start () {

		if (Application.loadedLevelName == "Level3_2" || Application.loadedLevelName == "Level4_2") {
		
			waveNum = 4;

		} else {
		
			waveNum = 3;
		
		}


		waveComing = true;
		waveCome ();
		//waveComing = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (currentWave>=waveNum)
			return;

//		if (waveComing) {
//		
//			waitTime += Time.deltaTime;
//
//			if(waitTime >= (spawnLimit) * spawnTime){
//				spawnNum = 0;
//				waveComing = false;
//				waitTime = 0;
//			}
//
//		}

		if (!waveComing) {
			
			waveTime += Time.deltaTime;
			
			if(waveTime >= timeBetweenNextWave){
				waveComing = true;
				waveCome();
				waveTime = 0;
			}
		}

	}

	void Spawn(){

		if (spawnNum >= spawnLimit) {
			CancelInvoke();
			spawnNum = 0;
			waveComing = false;
			return;
		}

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);

		rainAmount += enemy.transform.GetComponent<EnemyInfo> ().waterAmount;

		spawnNum++;
	}

	void waveCome(){
	
		if (!waveComing)
			return;

		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		currentWave++;
	
	}

}
