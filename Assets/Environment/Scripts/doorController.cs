/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      Open the door when action key is hit    *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour {
   private Animator objAnim;
   //private AudioSource objOpenAS;
   private bool isUsed;
   private Camera cam;

	// Use this for initialization
	void Start () 
   {
      objAnim   = GetComponent<Animator> ();
      //objOpenAS = GetComponent<AudioSource> ();
      isUsed = false;
      cam = Camera.main;
	}
	
   void OnTriggerStay(Collider target)
   {
      // When the player hits action key for the first time, open the door
      //************************************************************************
      // Need to check if the player has a key if not show that he needs key to 
      // open chest
      if (Input.GetKey (KeyCode.E) && target.tag == "Player") 
      {
            
            
         if (gameObject.tag == "toBalcony") 
         {
            objAnim.SetTrigger ("activateObject");
            StartCoroutine (toBalcony(target.transform));
         }
         else if (!isUsed) 
         {
               // code here to check if the player has key
               objAnim.SetTrigger ("activateObject");
               //objOpenAS.Play ();
         }      
         isUsed = true;
      }
   }

   IEnumerator toBalcony(Transform target)
   {
      yield return new WaitForSeconds (1.0f);
      target.position = new Vector3 (-162.82f, 6.2f, 15.6f);
      cam.GetComponent<CameraFollow2> ().enabled = false;
      cam.transform.position = new Vector3 (-157.92f, 12.0f, 0f);
   }
}
