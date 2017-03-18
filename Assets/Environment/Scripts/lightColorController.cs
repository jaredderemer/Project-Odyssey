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
 
   [SerializeField]
   private GameObject mask;
   private Light caveLight;
   [SerializeField]
   private Transform player;
   private bool notSet;

	// Use this for initialization
	void Start () 
   {
      caveLight = GetComponent<Light> ();	
      notSet = true;
	}

   void Update()
   {
      if (player.position.x >= -8.0f && notSet)
      {
         changeColor ();
         Camera.main.GetComponent<VignetteAndChromaticAberration> ().enabled = true;
         mask.SetActive (false);
         notSet = false;
      }
   }
	// Update is called once per frame
   public void changeColor () {
      caveLight.color = new Color (255.0f/255.0f, 192.0f/255.0f, 19.0f/255.0f, 255.0f);
	}
}
