using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterHut : MonoBehaviour
{
	bool byHut;
	private GameObject UI;
	
	GameObject thePlayer; // The player itself
	playerHealth thePlayerHealth; // Reference playerHealth Script

	// Use this for initialization
	void Start ()
	{
		UI = GameObject.Find("UI");
		
		thePlayer = GameObject.FindGameObjectWithTag("Player"); // Player is the player
		thePlayerHealth = thePlayer.GetComponent<playerHealth>(); // Get the player's health
	}
	
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
        {
			byHut = true;
        }
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
        {
			byHut = false;
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(byHut == true)
		{
			if(Input.GetKey("w"))
			{
				// Save data before switching scenes 
				thePlayerHealth.savePlayerHealth();
            globalController.Instance.nextSceneToLoad = "scene2";
				
				// Change scenes to loading
				UI.GetComponent<StartOptions>().StartLoadingScreen();
			}
		}
	}
}
