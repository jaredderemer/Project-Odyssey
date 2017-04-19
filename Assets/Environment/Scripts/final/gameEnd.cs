using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEnd : MonoBehaviour {

   private bool isUsed;
   private bool loadingScene = false;
   
   private GameObject   UI;

	// Use this for initialization
	void Start () 
   {
      isUsed = false;
      UI     = GameObject.Find("UI");  
	}

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && !isUsed) 
      {
         Destroy (gameObject);
         loadScene ();
         isUsed = true;
      }
   }

   public void loadScene ()
   {
      // Check if loading has already been started
      if(loadingScene == false)
      {
         // Set Global to load the correct sceneToLoad
         globalController.Instance.currentSceneIndex = 1;

         // Change scenes to loading
         UI.GetComponent<StartOptions>().StartLoadingScreen();

         loadingScene                        = true;

         // Index for the end movie clip to play
         globalController.Instance.clipIndex = 2;

         // Assign end time
         globalController.Instance.endTime = Time.time;
         Debug.Log (globalController.Instance.endTime);
      }
   }
}
