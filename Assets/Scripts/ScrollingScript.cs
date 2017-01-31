using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour 
{

	public Vector2 speed = new Vector2 (2, 2);
	public Vector2 direction = new Vector2 (-1, 0);
	public bool isLinkedToCamera = false;
	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	void Update () 
	{
		// Movement
		Vector3 movement = new Vector3 (
			speed.x * direction.x,
			speed.y * direction.y, 
			0);	

		movement *= Time.deltaTime;
		transform.Translate (movement);

		// Move the camera
		if (isLinkedToCamera) 
		{
			Camera.main.transform.Translate (movement);
		}
	}
}
