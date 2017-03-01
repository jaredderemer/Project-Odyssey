/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/27/17  14:00      Make an object blink                    *
* Juju Moong      02/27/17  21:15      Make public variables                   *
*                                                                              *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleController : MonoBehaviour {

   public float startTime; // Starting time to call the function
   public float duration;  // Repeat the function after the duration

   void Start ()
   {
      // Repeat the function after a certain time
      InvokeRepeating ("blinkObject", startTime, duration);
   }


   void blinkObject()
   {
      // Activate the game object if it is deactivated and vice versa
      if (gameObject.activeSelf) 
      {
         gameObject.SetActive (false);
      } 
      else 
      {
         gameObject.SetActive (true);
      }
   }
}
