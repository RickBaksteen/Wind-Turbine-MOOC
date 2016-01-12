using UnityEngine;
using System.Collections;

public class CameraMoving : MonoBehaviour {

	public float speed = 15f;
	public float zoomSpeed = 80f;

	private float zoomDistance = 0;

	bool rightclicked;
	Vector3 offset;
	Vector3 dragOrigin;

	Camera cam;

	// Use this for initialization
	void Start () {
		bool rightclicked = false;
		cam = gameObject.transform.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(1)){ 
			if(!rightclicked)
			{
				dragOrigin = Input.mousePosition;
				rightclicked = true;
			}
		} 
		if (Input.GetMouseButtonUp(1)){ 
			rightclicked = false; 
		}

//		if (Input.GetMouseButtonDown(1))
//		{
//			dragOrigin = Input.mousePosition;
//			return;
//		}
//		
//		if (!Input.GetMouseButton(1)) 
//			return;
//		
//		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
//		Vector3 move = new Vector3(-pos.x * speed, 0, -pos.y * speed);
//		
//		transform.Translate(move, Space.World); 

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		//Debug.Log (scroll);
		//transform.Translate(0, scroll * zoomSpeed , 0, Space.World);
		cam.orthographicSize -= scroll*zoomSpeed;

	}

	void LateUpdate()
	{
		if (rightclicked) {

			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
			Vector3 move = new Vector3(-pos.x * speed, 0, -pos.y * speed);
			
			transform.Translate(move, Space.World); 
		}
		
	}
}
