/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32                                              *
*                                                                              *
*                                                                              *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartController : MonoBehaviour {

   Animator cartAnim;

	// Use this for initialization
	void Start () 
   {
      cartAnim = GetComponent<Animator> ();
	}

   void OnTriggerEnter (Collider target)
   {
      if (target.tag == "Player") 
      {
         cartAnim.SetTrigger ("activateCart");
      }
   }
}
