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
      if (Input.GetKey (KeyCode.W) && col.tag == "Player") 
      {
         yield return new WaitForSeconds (1.0f);
         col.transform.position = new Vector3 (-110.8f, 5.9f, 15.6f);
         cam.transform.position = new Vector3 (-114.95f, 4.5f, 0f);
         cam.GetComponent<CameraFollow2> ().enabled = true;
      }
   }
}
