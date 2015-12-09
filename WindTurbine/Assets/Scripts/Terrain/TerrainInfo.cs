using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class TerrainInfo : MonoBehaviour {
	
	public float pathHeight = 1f;
	public int[,] gridInfo = new int[20, 20];
	public int[,] elevationInfo = new int[20, 20];
	
	public int elevationInterval = 5;
	public int elevationMax = 100;
	
	private int indexMax;
	private int indexMin;
	
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
		
		
		loadElevation ();
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
	
	
	public void loadElevation(){
		
		int elevationBound = elevationMax / elevationInterval + 1;
		int currentIndex = 0;
		int prevIndexX = 0;
		int prevIndexZ = 0;
		
		indexMin = elevationBound - 1;
		indexMax = 0;
		
		for (int x = 0; x < 20; x++) {
			
			for(int z = 0; z < 20; z++){
				
				if (x == 0 && z == 0){
					
					currentIndex = UnityEngine.Random.Range(0, elevationBound);
					
				}
				
				else if (x == 0){
					
					prevIndexZ = elevationInfo[x, z - 1];
					currentIndex = UnityEngine.Random.Range(Math.Max(prevIndexZ - 1, 0), Math.Min(prevIndexZ + 2, elevationBound));
					
				}
				
				else if (z == 0){
					
					prevIndexX = elevationInfo[x - 1, z];
					currentIndex = UnityEngine.Random.Range(Math.Max(prevIndexX - 1, 0), Math.Min(prevIndexX + 2, elevationBound));
				}
				
				else {
					
					prevIndexX = elevationInfo[x - 1, z];
					prevIndexZ = elevationInfo[x, z - 1];
					
					int min = Math.Max(Math.Max(prevIndexX - 1, prevIndexZ - 1), 0);
					int max = Math.Min(Math.Min(prevIndexX + 2, prevIndexZ + 2), elevationBound);
					currentIndex = UnityEngine.Random.Range(min, max);
				}
				
				elevationInfo[x, z] = currentIndex;
				indexMax = Math.Max (currentIndex, indexMax);
				indexMin = Math.Min (currentIndex, indexMin);
				
			}
			
		}
		
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
		int elevationBound = elevationMax / elevationInterval;
		
		for (int x = 0; x < 20; x++) {
			
			for(int z = 0; z < 20; z++){
				
				if(gridInfo[x, z]==0)
				{
					Transform newGrid = (Transform)Instantiate(placeHolderTile, GridToTranform(x, z), Quaternion.identity);
					newGrid.SetParent(gameObject.transform);
					GridInfo newGridInfo = newGrid.GetComponent<GridInfo>();
					newGrid.GetComponent<MeshRenderer>().material.SetFloat("_Metallic", 1f / (float) (indexMax-indexMin) * (float)(elevationInfo[x, z]-indexMin));
					newGridInfo.Elevation = elevationInfo[x, z] * elevationInterval;
					newGridInfo.setAttribute();
				}
				
				else if(gridInfo[x, z] == 1)
				{
					Transform newGrid = (Transform)Instantiate(routeTile, GridToTranform(x, z), Quaternion.identity);
					newGrid.SetParent(gameObject.transform);
					GridInfo newGridInfo = newGrid.GetComponent<GridInfo>();
					newGridInfo.Elevation = elevationInfo[x, z] * elevationInterval;
					newGridInfo.setAttribute();
				}
				
			}
			
		}
	}
}
