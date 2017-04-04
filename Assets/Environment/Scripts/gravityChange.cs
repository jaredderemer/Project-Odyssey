/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      04/03/17  15:20      Change the gravity when triggered       *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityChange : MonoBehaviour {

   public float newGravity;

   private float orgGravity;
   private GameObject gravityGO;

   void Start ()
   {
      gravityGO  = GameObject.Find ("gravity");
      orgGravity = gravityGO.GetComponent<gravityController> ().gravity.y;
      gravityGO.GetComponent<gravityController> ().changeGravity(orgGravity);
   }

   /****************************************************************************
   * OnTriggerStay                                                             *
   * Change the gravity when triggered                                         *
   ****************************************************************************/
   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player")
      {
         gravityGO.GetComponent<gravityController> ().changeGravity(newGravity);
      }
   }

   /****************************************************************************
   * OnTriggerExi                                                              *
   * Reset the gravity to its orginal value set                                *
   ****************************************************************************/
   void OnTriggerExit (Collider col)
   {
      if (col.tag == "Player")
      {
         gravityGO.GetComponent<gravityController> ().changeGravity(orgGravity);
      }
   }
}
