/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      Destroy an item                         *
* Juju Moong      02/24/17  15:32      Instantiate a random object             *
* Juju Moong      02/26/17  14:10      Change List type variable to public     *
*                                      array of GameObject                     *
*                                                                              *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour {

   public GameObject[] objList;
   public float delay;

   private int index;

   IEnumerator OnTriggerStay(Collider col)
   {      
      // When the player hits an action key, destroy the item the player 
      // collides with, and randomly generate an item from the item list.
      if (Input.GetKey (KeyCode.E)) 
      {
         if (col.tag == "Player") 
         {
            Destroy (gameObject, delay);
            index = (int)Random.Range (0, objList.Length);
            Instantiate (objList [index], 
               new Vector3 (transform.position.x, 
                  transform.position.y + 0.7f, 
                  transform.position.z + 0.132f), 
               Quaternion.identity);
         } 
         //*********************************************************************
         // Can only destroy when player has master key
         else if (col.tag == "Key") // NEED TO TEST WHEN PLAYER CAN CARRY KEYS
         {
            Destroy (gameObject, delay);
            yield return new WaitForSeconds (2.0f);
            Instantiate (objList [0], 
               new Vector3 (transform.position.x, 
                  transform.position.y + 0.7f, 
                  transform.position.z + 0.132f), 
               Quaternion.identity);
         }
      }
   }
}
