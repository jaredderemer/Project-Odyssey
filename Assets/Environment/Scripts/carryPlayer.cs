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

public class carryPlayer : MonoBehaviour {

   private Transform target;
   private Vector3 offset;

   // Use this for initialization
   void Start () 
   {
      target = null;
   }

   void OnTriggerStay(Collider collider)
   {
      target = collider.transform;
      offset = target.position - transform.position;
   }

   void OnTriggerExit(Collider collider)
   {
      target = null;
   }

   // Update is called once per frame
   void Update () 
   {
      // When there is collision, move both game objects
      if (target != null) 
      {
         target.position = transform.position + offset;
      }
   }
}
