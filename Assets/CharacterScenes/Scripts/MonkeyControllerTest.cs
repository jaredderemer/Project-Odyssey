using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyControllerTest : MonoBehaviour {

	[HideInInspector]public bool playerInView = false;
	[HideInInspector]public GameObject player;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerInView)
		{
			move ();
			followPlayer ();
		}
	}

	void move()
	{
		// This is where the animation states will change depending on where the character is in relation to the monkey
	}

	void followPlayer()
	{
		Debug.Log ("Player has been found");
	}
}
