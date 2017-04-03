/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      When the player enters a certain area,  *
*                                      play the animated rock spikes.          *
*                                                                              *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeController : MonoBehaviour {

   private Animator spikeAnim;

   private bool flag;

   // Use this for initialization
   void Start () 
   {
      spikeAnim = GetComponent<Animator> (); // Get the animator from the game object
      flag = false;
   }

   void Update()
   {
      // When the player is in the area, keep playing the animation
      if (flag)
      {
         spikeAnim.SetTrigger ("activateSpike");
         flag = false;
      }
   }

   void OnTriggerStay (Collider target)
   {
      if (target.tag == "Player") 
      {
         spikeAnim.SetTrigger ("activateSpike");
         flag = true;
      }
   }

   void OnTriggerExit (Collider target)
   {
      if (target.tag == "Player") 
      {
         flag = false;
      }
   }
}
