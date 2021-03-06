﻿/****************************************************************************** 
* Author            MM/DD/YY HH24:MM   Description                            * 
* Jonathan Rigsby   02/23/17 21:30     Script to climb ladder in decision hut *
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
   public float     speed;
   public float     leftLimit;
   public float     rightLimit;
   public Transform target;
   
   void Update ()
   {
      // Climb if the player is positioned in front of the ladder and pressing W
      if (transform.position.x > leftLimit && transform.position.x < rightLimit && Input.GetKey("e"))
      {
         if (transform.rotation.y != 0.0f)
         {
            transform.Rotate(0.0f, -90.0f, 0.0f);
         }
         
         // Make sure the character is rotated in the correct direction
         if (!gameObject.GetComponent<playerController>().facingRight)
         {
            gameObject.GetComponent<playerController>().Flip();
         }
         
         float step = speed * Time.deltaTime;
         transform.position = Vector3.MoveTowards(transform.position, target.position, step);
         
        // else if (gameObject.GetComponent<playerController>().facingRight)
        // {
            //Debug.Log("In nested else if");
        //    transform.Rotate(0.0f, -90.0f, 0.0f);
        // }
        // else
        // {
            //Debug.Log("In nested else");
        //    transform.Rotate(0.0f, 90.0f, 0.0f);
        // }
      }
     // else if (transform.position.x > leftLimit && transform.position.x < rightLimit)
     // {
         // Display "W" key prompt
     // }
   }
}