/****************************************************************************** 
* Author            MM/DD/YY HH24:MM   Description                            * 
* Jonathan Rigsby   02/23/17 21:30     Script to climb ladder in decision hut *
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
   public float     speed;
   public Transform target;
          bool      byLadder;
   
   void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Climb"))
      {
         byLadder = true;
         
         if (transform.rotation.y != 0.0f)
         {
            transform.Rotate(0.0f, -90.0f, 0.0f);
         }
         
         // Make sure the character is rotated in the correct direction
         if (!gameObject.GetComponent<playerController>().facingRight)
         {
            gameObject.GetComponent<playerController>().Flip();
         }
      }
   }
   
   void OnTriggerExit(Collider other)
   {
      if (other.gameObject.CompareTag("Climb"))
      {
         byLadder = false;
         
         transform.Rotate(0.0f, 90.0f, 0.0f);
      }
   }
   
   void Update ()
   {
      // Climb if the player is positioned in front of the ladder and pressing W
      if (byLadder == true)
      {
         if (Input.GetKey("w"))
         {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
         }
         else
         {
            // Make sure the character is rotated in the correct direction
            if (!gameObject.GetComponent<playerController>().facingRight)
            {
               gameObject.GetComponent<playerController>().Flip();
            }
         }
         
      }
   }
}