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
      if (Input.GetKey (KeyCode.E) && !isUsed && target.tag == "Player") 
      {
            // code here to check if the player has key
            objAnim.SetTrigger ("activateObject");
            //objOpenAS.Play ();
         isUsed = true;
         if (gameObject.tag == "toBalcony") 
         {
            StartCoroutine (toBalcony(target.transform));
         }
      }
   }

   IEnumerator toBalcony(Transform target)
   {
      yield return new WaitForSeconds (1.0f);
      target.position = new Vector3 (-43.0f, 1.9f, 1.47f);
      cam.GetComponent<CameraFollow2> ().enabled = false;
      cam.transform.position = new Vector3 (-39.0f, 5.85f, -10.0f);
   }
}
