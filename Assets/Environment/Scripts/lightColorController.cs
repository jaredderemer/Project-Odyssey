/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      03/18/17  13:42      Change the light color and enable       *
*                                      camera vignette effect                  *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class lightColorController : MonoBehaviour {
 
   private GameObject mask;
   private Light caveLight;
   private Transform player;
   private bool notSet;

	// Use this for initialization
	void Start () 
   {
      mask      = GameObject.FindGameObjectWithTag ("Mask");
      player    = GameObject.FindGameObjectWithTag ("Player").transform;
      caveLight = GetComponent<Light> ();	
      notSet    = true;
	}

   void Update()
   {
      if (player.position.x >= -8.0f && notSet) 
      {
         changeColor (245.0f/255.0f, 195.0f/255.0f, 70.0f/255.0f);
         Camera.main.GetComponent<VignetteAndChromaticAberration> ().enabled = true;
         mask.SetActive (false);
         notSet = false;
      } 
      else if (player.position.x < -8.0f && !notSet)
      {
         changeColor (255.0f/255.0f, 244.0f/255.0f, 216.0f/255.0f);
         Camera.main.GetComponent<VignetteAndChromaticAberration> ().enabled = false;
         mask.SetActive (true);
         notSet = true;
      }
   }
	// Update is called once per frame
   public void changeColor (float r, float g, float b) {
      caveLight.color = new Color (r, g, b, 255.0f);
	}
}
