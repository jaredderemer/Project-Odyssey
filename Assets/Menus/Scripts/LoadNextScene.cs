using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
   private int loadingCounter = 0;
   public Text progressText;
   private int sceneIndex;
   AsyncOperation async;
   
   // Initialize level to be loaded and start scene load
   void Start()
   {
      // Get the next scene to load
      sceneIndex = globalController.Instance.currentSceneIndex + 1;
      globalController.Instance.currentSceneIndex = sceneIndex;

		Debug.Log("Loading Next Scene " + sceneIndex.ToString() + " with spawnpoint " + globalController.Instance.spawnpoints[globalController.Instance.currentSceneIndex].x + ", " + globalController.Instance.spawnpoints[globalController.Instance.currentSceneIndex].y + ", " + globalController.Instance.spawnpoints[globalController.Instance.currentSceneIndex].z);      
      StartCoroutine ("load");
      
      
   }

    // Pseudo loading screen for between scenes
   void Update()
   {
      // Check if loading counter has reached 100 percent
      if(loadingCounter < 100)
      {
         // Display current loading percent and increment
         progressText.text = loadingCounter + "%";
         loadingCounter++;
      }
      else
      {
         // Diplay 100 percent loaded and activate next scene
         progressText.text = loadingCounter + "%";
         async.allowSceneActivation = true;
      }
   }

   // Loads next scene asynchronously in the background
   IEnumerator load()
   {
      // Start scene load and wait for scene to be activated
      async = SceneManager.LoadSceneAsync (sceneIndex);
      async.allowSceneActivation = false;

      yield return async;
   }

   // Activate the next scene
   public void ActivateScene()
   {
      async.allowSceneActivation = true;
   }
}
