using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEnd : MonoBehaviour {

   private bool isUsed;
   private bool loadingScene = false;
   
   private GameObject   UI;
	private GameObject   thePlayer; // The player itself
	private playerHealth thePlayerHealth; // Reference playerHealth Script

	// Use this for initialization
	void Start () 
   {
      isUsed = false;

      UI = GameObject.Find("UI");
		
		thePlayer = GameObject.FindGameObjectWithTag("Player"); // Player is the player
		thePlayerHealth = thePlayer.GetComponent<playerHealth>(); // Get the player's health      
	}

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && !isUsed) 
      {
         Destroy (gameObject);

         // load ending scene
         // Check if loading has already been started
         if(loadingScene == false)
         {
            // Save data before switching scenes 
            thePlayerHealth.savePlayerHealth();
         
            // HARD CODE: put index to go to final cinematic
            globalController.Instance.currentSceneIndex = 5;
         
            // Change scenes to loading
            UI.GetComponent<StartOptions>().StartLoadingScreen();
            
            loadingScene = true;
         }
         
         

         isUsed = true;
      }
   }
}
