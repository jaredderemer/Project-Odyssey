﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Drop_2 : MonoBehaviour
{
    Vector3 myCordinates;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// Pickups that touches this ground gets gravity turned off
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pickups"))
		{
			other.GetComponent<Rigidbody>().useGravity = false;
            myCordinates.Set(1,3,5);
            //other.GetComponent<Rigidbody>().transform.position
		}
	}
	
	void OnCollisionEnter (Collision col)
    {
		
		
	}
}
