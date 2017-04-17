using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movieController : MonoBehaviour {

   public int index; // 1 == intro; 2 == end

   bool loadingScene = false;
   private GameObject UI;
   private MovieTexture movie;
   private Material material;
   private GameOver gameOverScript;
	
   // Use this for initialization
	void Start () 
   {
      UI             = GameObject.Find("UI");
      gameOverScript = GameObject.Find("UI").GetComponent<GameOver> ();
      index          = globalController.Instance.clipIndex;
      playClip ();
   }
	
	// Update is called once per frame
	void Update () 
   {
      index = globalController.Instance.clipIndex;

      if (!(movie.isPlaying)) 
      {
         if (index == 1) 
         {
            selectScene ();
         } 
         else 
         {
            // CANNOT INTERACT
            globalController.Instance.gameOver = true;
            gameOverScript.endGame ();
         }
      }
	}

   public void playClip ()
   {
      string mat = (index == 1) ? "intro" : "end";
      material = Resources.Load(mat, typeof(Material)) as Material;
      gameObject.GetComponent<MeshRenderer> ().material = material;

      movie = (MovieTexture)GetComponent<Renderer> ().material.mainTexture;
      // this line of code will make the Movie Texture begin playing
      movie.Play();
   }

   void selectScene ()
   {
      // Check if loading has already been started
      if(loadingScene == false)
      {
         // Set Global to load the correct sceneToLoad
         globalController.Instance.currentSceneIndex = 2; // beach + jungle scene
         // Change scenes to loading
         UI.GetComponent<StartOptions>().StartLoadingScreen();

         loadingScene = true;
      }
   }
}
