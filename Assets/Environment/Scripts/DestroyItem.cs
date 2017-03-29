/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      Destroy an item                         *
*                                      Instantiate a random object             *
* Juju Moong      02/26/17  14:10      Change List type variable to public     *
*                                      array of GameObject                     *
* Juju Moong      03/29/17  02:05      Check if player has item needed to      *
*                                      destroy an object                       *
*                                                                              *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour {

   public GameObject[] objList;

   [SerializeField]
   private int itemIDNeeded; // Item ID necessary to unlock an object
   private int index;

   void OnTriggerStay(Collider col)
   {      
      // When the player hits an action key, destroy the item the player 
      // collides with, and randomly generate an item from the item list.
      if (Input.GetKey (KeyCode.E) && col.tag == "Player") 
      {
         if (gameObject.tag == "Locked") 
         {
            unlockObject (col);
         } 
         else 
         {
            destroyObject ();
         }
      }
   }

   void unlockObject (Collider target)
   {
      if (target.GetComponent<Inventory2> ().removeItem (itemIDNeeded) == 1) 
      {
         gameObject.tag = "Untagged";
         destroyObject ();
      }
   }

   void destroyObject ()
   {  
      Destroy (gameObject);
      index = (int)Random.Range (0, objList.Length);
      Instantiate (objList [index], 
                   new Vector3 (transform.position.x, 
                                transform.position.y + 0.7f, 
                                transform.position.z + 0.132f), 
                   Quaternion.identity);
   }
}
