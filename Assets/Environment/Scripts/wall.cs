/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      03/18/17  23:37      Enable cave wall upon entering          *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour {

   private BoxCollider wall_col;
   private bool isEnabled;
   [SerializeField]
   private Transform player;

   void Start ()
   {
      wall_col = gameObject.GetComponent<BoxCollider> ();
      isEnabled   = false;
   }

   void OnTriggerEnter (Collider col)
   {
      // When player enters the trigger and the wall collider is not enabled yet,
      // enable the collider and reset the minimum x position of the Camera
      if (col.tag == "Player" && !isEnabled) 
      {
         wall_col.enabled = true;
         //Camera.main.GetComponent<CameraFollow2> ().minPosX = 4.5f;
         isEnabled = true;
      }
   }

   void Update ()
   {
      // Disable cave wall collider and reset the minimum Camera x position
      // for player respawning purposes
      if (player.position.x <= -6.1f) 
      {
         wall_col.enabled = false;
         //Camera.main.GetComponent<CameraFollow2> ().minPosX = -81.5f;
         isEnabled = false;
      }
   }
}