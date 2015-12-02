using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TerrainInfo : MonoBehaviour {

	public float pathHeight = 2f;
	public int[,] gridInfo = new int[20, 20];
	List<Transform> routeTurningPoints = new List<Transform>();
	List<Vector2> gridTurningPoints = new List<Vector2>();

	public Transform placeHolderTile;
	public Transform routeTile;

	// Use this for initialization
	void Start () {

		Transform turningPointsObject = GameObject.FindGameObjectWithTag ("routeTurningPoints").transform;
		int i = 0;
		
		while (i < turningPointsObject.childCount) {
			routeTurningPoints.Add (turningPointsObject.GetChild (i).transform);
			gridTurningPoints.Add(TransformToGrid(turningPointsObject.GetChild (i).transform.position));
			//Debug.Log ("Turning Points" + gridTurningPoints[i]);
			i++;
		}

		loadMap ();
		buildMap ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector3 GridToTranform(int x, int z){
	
		return new Vector3 ((float)(10 * x - 95), pathHeight,(float)( -10 * z + 95));
	
	}

	public Vector2 TransformToGrid(Vector3 newVector){
	
		return new Vector2 ((int)(newVector.x + 95) / 10, (int)(95 - newVector.z) / 10);
	
	}

	public void loadMap(){

		for (int x = 0; x < 20; x++) {

			for(int z = 0; z < 20; z++){

				gridInfo[x,z] = 0;

			}

		}

		Vector2 prev = new Vector2 (0, 19);

		for (int i = 0; i < gridTurningPoints.Count; i++) {
		
			loadRoute (prev, gridTurningPoints[i]);
			prev = gridTurningPoints[i];
		
		}

	}


	private void loadRoute(Vector2 prev, Vector2 after)
	{
		if ((int)prev.x == (int)after.x) {

			int max = Math.Max((int)prev.y, (int)after.y);
			int min = Math.Min((int)prev.y, (int)after.y);
		
			for(int i = min; i<= max; i++){

				gridInfo[(int)prev.x, i] = 1;
			
			}
		
		}

		if ((int)prev.y == (int)after.y) {

			int max = Math.Max((int)prev.x, (int)after.x);
			int min = Math.Min((int)prev.x, (int)after.x);
			
			for(int i = min; i<=max; i++){

				gridInfo[i, (int)prev.y] = 1;
			
			}
			
		}
	}

	public void buildMap()
	{

		for (int x = 0; x < 20; x++) {
			
			for(int z = 0; z < 20; z++){
				
				if(gridInfo[x, z]==0)
				{
					Instantiate(placeHolderTile, GridToTranform(x, z), Quaternion.identity);
					//newGrid.transform.SetParent(gameObject.transform);
				}

				else if(gridInfo[x, z] == 1)
				{
					Instantiate(routeTile, GridToTranform(x, z), Quaternion.identity);
					//newGrid.transform.SetParent(gameObject.transform);
				}

			}
			
		}
	}
}
