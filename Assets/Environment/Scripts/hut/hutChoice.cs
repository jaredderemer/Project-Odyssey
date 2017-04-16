using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hutChoice : MonoBehaviour
{
	bool byChoice;
   bool loadingScene = false;
	private GameObject UI;
   [HideInInspector]
   public int sceneToLoad;

	// Use this for initialization
	void Start ()
	{
		UI = GameObject.Find("UI");
      sceneToLoad = 2; // Default scene is Cave
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
      {
         byChoice = true;
      }
	}
      
   void OnTriggerStay(Collider other)
   {
      if(other.tag == "Player")
      {
         if (Input.GetKey (KeyCode.W)) 
         {   
            loadScene ();
         }
         else if (gameObject.tag == "Finish") 
         {
            sceneToLoad = 5; // final scene
            loadScene (); 
         }
      }
   }
	
   public void loadScene ()
   {
      // Check if loading has already been started
      if(loadingScene == false)
      {
         // Set Global to load the correct sceneToLoad
         globalController.Instance.currentSceneIndex = sceneToLoad;

         // Change scenes to loading
         UI.GetComponent<StartOptions>().StartLoadingScreen();

         loadingScene = true;
      }
   }

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
      {
			byChoice = false;
      }
	}
}
