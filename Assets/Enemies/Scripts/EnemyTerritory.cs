﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour {

	public BoxCollider territory;
    GameObject player;
	[HideInInspector]public bool playerInTerritory;

	public GameObject enemy;
	EnemyController basicenemy;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		basicenemy = enemy.GetComponent <EnemyController> ();
		playerInTerritory = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (playerInTerritory == true)
		{
			basicenemy.MoveToPlayer ();
		}

		if (playerInTerritory == false)
		{
			basicenemy.Rest ();
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player)
		{
			playerInTerritory = true;
		}
	}

//	void OnTriggerExit (Collider other)
//	{
//		if (other.gameObject == player) 
//		{
//			playerInTerritory = false;
//		}
//	}
}
