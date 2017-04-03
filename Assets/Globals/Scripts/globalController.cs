﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalController : MonoBehaviour
{
	public float playerHealth;
   public int playerAmmo;
   public int playerScore;
   public int currentSceneIndex;
	[HideInInspector]public bool gameOver;

	[HideInInspector]public Dictionary<int, Vector3> spawnpoints = new Dictionary<int, Vector3> ();
	public GameObject scene1Spawnpoint;
	public GameObject scene2Spawnpoint;
	public GameObject scene3Spawnpoint;
	public GameObject scene4Spawnpoint;
	
	public static globalController Instance;
   
	void Start ()
	{
		playerHealth = 100.0f;
      playerAmmo   = 0;

		spawnpoints [2] = scene1Spawnpoint.transform.position;
		spawnpoints [3] = scene2Spawnpoint.transform.position;
		spawnpoints [4] = scene3Spawnpoint.transform.position;
		spawnpoints [5] = Vector3.zero;//scene4Spawnpoint.transform.position;

		gameOver = false;
	}

    void Awake ()   
	{
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
    }
}
