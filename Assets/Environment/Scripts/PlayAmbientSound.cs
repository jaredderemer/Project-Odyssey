/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32                                              *
*                                                                              *
*                                                                              *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAmbientSound : MonoBehaviour {

   public float minPosition; // the endpoints of the area sound will be playing
   public float maxPosition;

   public Transform target;

   AudioSource ambientAS;
   bool musicOn;

   void Start()
   {
      musicOn = false;
      ambientAS = GetComponent<AudioSource> ();
   }
   void Update ()
   {
      // if the target is within the area and music is not on, play the ambient sound effect
      if (target.position.x >= minPosition && target.position.x <= maxPosition) 
      {
         if (!musicOn) 
         {
            musicOn = true;
            ambientAS.Play ();  
         }
      } 
      else 
      {
         musicOn = false;
         ambientAS.Stop ();
      }
   }
}
