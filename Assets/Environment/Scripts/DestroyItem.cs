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

   private int index;

   void OnTriggerStay(Collider collider)
   {
      // When the player hits an action key, destroy the item the player 
      // collides with, and randomly generate an item from the item list.
      if (Input.GetKey (KeyCode.E) && collider.tag == "Player") 
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
}
