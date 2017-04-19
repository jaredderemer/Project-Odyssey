using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movieController : MonoBehaviour {

   public int index; // 1 == intro; 2 == end
   public GameObject text;
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
      //index = 2; // for testing purpose
      playClip ();
   }
	
	// Update is called once per frame
	void Update () 
   {
      index = globalController.Instance.clipIndex;

      // To skip video
      if (index == 1) 
      {
         if (movie.isPlaying) 
         {
            text.SetActive (true);
            if (Input.GetKey (KeyCode.Space)) 
            {
               selectScene ();
               text.SetActive (false);
            }
         }
      }

      if (!(movie.isPlaying)) 
      {
         // Check if first movie and scene is not yet loading
         if (index == 1 && !loadingScene) 
         {
            selectScene ();
         } 
         // Check if game has been set to over
         else if(!globalController.Instance.gameOver)
         {
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