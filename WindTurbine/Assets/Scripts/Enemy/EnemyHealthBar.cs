using UnityEngine;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {

	public Transform target;

	public int maxHealth = 100;
	public int curHealth = 100;
	
	public float healthBarLength;
	
	// Use this for initialization
	void Start () {
		target = gameObject.GetComponentInParent<Transform> ();
		healthBarLength = Screen.width / 6;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 screenPos =  Camera.main.WorldToScreenPoint(target.position);
		//Debug.Log("target is " + screenPos.x + " pixels from the left");
		AddjustCurrentHealth(0);   
	}
	
	void OnGUI() {
		GUI.Box(new Rect(700, 10, healthBarLength, 20), curHealth + "/" + maxHealth);
	}
	
	public void AddjustCurrentHealth(int adj) {
		curHealth += adj;
		
		if (curHealth < 0)
			curHealth = 0;
		
		if (curHealth > maxHealth)
			curHealth = maxHealth;
		
		if(maxHealth < 1)
			maxHealth = 1;
		
		healthBarLength = (Screen.width / 6) * (curHealth /(float)maxHealth);
	}

}
