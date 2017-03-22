/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      Open an object when action key is hit   *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour {
   private Animator objAnim;
   //private AudioSource objOpenAS;
   private bool isUsed;

	// Use this for initialization
	void Start () 
   {
      objAnim   = GetComponent<Animator> ();
      //objOpenAS = GetComponent<AudioSource> ();
      isUsed = false;
	}
	
   void OnTriggerStay(Collider target)
   {
      // When the player hits action key for the first time, open the door
      //************************************************************************
      // Need to check if the player has a key if not show that he needs key to 
      // open chest
      if (Input.GetKey (KeyCode.E) && !isUsed && target.tag == "Player") 
      {
            // code here to check if the player has key
            objAnim.SetTrigger ("activateObject");
            //objOpenAS.Play ();
            isUsed = true;
      }
   }
}
