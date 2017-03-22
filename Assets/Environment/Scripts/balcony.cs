/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      03/23/17  14:45      Go back to the room from balcony        *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balcony : MonoBehaviour {

   private Camera cam;

   void Start ()
   {
      cam = Camera.main;
   }

   IEnumerator OnTriggerStay (Collider col)
   {
      if (Input.GetKey (KeyCode.Q) && col.tag == "Player") 
      {
         yield return new WaitForSeconds (1.0f);
         col.transform.position = new Vector3 (15.0f, 6.75f, 0.14f);
         cam.transform.position = new Vector3 (15.0f, 12.0f, -10.0f);
         cam.GetComponent<CameraFollow2> ().enabled = true;
      }
   }
}
