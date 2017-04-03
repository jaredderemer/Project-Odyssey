/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      When the player collides with a moving  *
*                                      object, take him with it to the new     *
*                                      position.                               *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caveEnter : MonoBehaviour {
   public float dampTime;
   public float length;

   private bool isTriggered;
   private Transform player;
   private Vector3 desiredPosition;
   private Vector3 moveVelocity;

	// Use this for initialization
	void Start () 
   {
      player          = GameObject.FindGameObjectWithTag ("Player").transform;
      isTriggered     = false;
	}
	
   void OnTriggerEnter (Collider col)
   {
      if (col.tag == "Player") 
      {
         isTriggered = true;
         desiredPosition = new Vector3 (player.position.x + length, 
                                        1.3f, player.position.z);
      }
   }
	
   void Update ()
   {
      if (isTriggered) 
      {
         player.position = Vector3.SmoothDamp (player.position, desiredPosition, 
                                               ref moveVelocity, dampTime);
      }

      if (player.position.x >= (desiredPosition.x - 0.5f)) 
      {
         isTriggered = false;
      }
   }
}
