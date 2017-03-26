/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      03/22/17  15:32      Open the door when action key is hit    *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour {

   [SerializeField]
   private int itemIDNeeded; // Item ID necessary to unlock an object
   private Animator objAnim;
   private AudioSource objOpenAS;
   private bool isUsed;
   private bool displayed;
   private Camera cam;
   private GameObject messageTemp;

	// Use this for initialization
	void Start () 
   {
      objAnim     = GetComponent<Animator> ();
      objOpenAS   = GetComponent<AudioSource> ();
      messageTemp = GameObject.FindGameObjectWithTag ("MessageTemp");
      isUsed      = false;
      displayed   = false;
      cam         = Camera.main;
	}
	
   void OnTriggerStay(Collider target)
   {
      // When the player hits action key, open the door 
      if (Input.GetKey (KeyCode.E) && target.tag == "Player") 
      {
         if (gameObject.tag == "Locked" && !isUsed) 
         {
            // Check if the player has key to unlock door
            if (target.GetComponent<Inventory2> ().removeItem (itemIDNeeded) == 1) 
            {
               objAnim.SetTrigger ("activateObject");
               objOpenAS.Play ();
               isUsed = true;
            } 
            else 
            {
               if (!displayed) 
               {
                  messageTemp.GetComponent<noteDisplay>().displayMessage("Door is locked");
                  displayed = true;
               }
            }
         }

         // if the door opens to balcony, move player to the balcony
         // this action can be done more than once, no key is needed
         if (gameObject.tag == "toBalcony") 
         {
            StartCoroutine (toBalcony(target.transform));
         }
      }
   }

   void OnTriggerExit (Collider target)
   {
      messageTemp.GetComponent<noteDisplay>().displayMessage("");
      displayed = false;
   }

   IEnumerator toBalcony(Transform target)
   {
      yield return new WaitForSeconds (1.0f);
      target.position = new Vector3 (-162.82f, 6.2f, 15.6f);
      cam.GetComponent<CameraFollow2> ().enabled = false;
      cam.transform.position = new Vector3 (-157.92f, 12.0f, 0f);
   }
}
