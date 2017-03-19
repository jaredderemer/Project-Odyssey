/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      Make the camera follows the player      *
*                                      Set X endpoints so that the camera      *
*                                      won't go pass them                      *
* Will Reaves                          ????
* Juju Moong      03/06/17  23:00      ????
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
   public float dampTime = 0.2f;
   public float maxPosX;
   public float minPosX;
   public int path;
   public Transform player;

   private Vector3 moveVelocity;
   private Vector3 desiredPosition;
   private float originalY;

   private void Start ()
   {
      originalY = transform.position.y;
   }

   private void FixedUpdate()
   {
      if (player != null) 
      {
         if (player.position.x >= maxPosX || player.position.x <= minPosX) 
         {
            StopCamera ();
         } 
         else 
         {
            Move ();
         }
      }
   }

   private void Move()
   {
      FindPosition();

      transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, 
                                              ref moveVelocity, dampTime);
   }

   private void FindPosition()
   {
      Vector3 pos = new Vector3();

      pos.x   = player.position.x;
      if (player.GetComponent<playerController> ().facingRight) 
      {
         pos.x += 5.0f; // Keeps camera slightly in front of player
      } 

      switch (path) 
      {
         case 1:
            pos.y = followPathOne ();
            break;
         case 2:
            pos.y = followPathTwo ();
            break;
      }

      pos.z = transform.position.z;

      desiredPosition = pos;
   }

   public void StopCamera()
   {
      FindPosition();

      desiredPosition.x = transform.position.x;

      transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, 
                                              ref moveVelocity, dampTime);
   }

   private float followPathOne ()
   {
      float posY;

      if (player.position.y >= 4.0f) 
      {
         posY = 5.0f;
      } 
      else 
      {
         posY = originalY;
      }
      return posY;
   }

   private float followPathTwo()
   {
      float posY;

      if (player.position.x >= 202.0f && 
          player.position.x <= 214.5f &&
          player.position.y < 7.2f) 
      {
         posY = 5.0f;
      }
      else if (player.position.y >= 16f) 
      {
         posY = 18.0f;
      } 
      else if (player.position.y >= 7.2f) 
      {
         posY = 14.0f;
      } 
      else if (player.position.y >= 1.2f)
      {
            posY = 8.0f;  
      }  
      else if (player.position.y >= -5.0f) 
      {
         posY = 4.0f;
      }
      else 
      {
         posY = player.position.y;
      }
      return posY;
   }
}
