/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      03/17/17  15:20      Change the gravity when triggered       *
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
      gravityGO = GameObject.Find ("gravity");
      orgGravity = gravityGO.GetComponent<gravityController> ().gravity.y;
      gravityGO.GetComponent<gravityController> ().changeGravity(orgGravity);
   }

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player")
      {
         gravityGO.GetComponent<gravityController> ().changeGravity(newGravity);
      }
   }

   void OnTriggerExit (Collider col)
   {
      if (col.tag == "Player")
      {
         gravityGO.GetComponent<gravityController> ().changeGravity(orgGravity);
      }
   }
}
