/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      Make the camera follows the player      *
*                                      Set X endpoints so that the camera      *
*                                      won't go pass them                      *
* Will Reaves                          ????
* Juju Moong      03/06/17  23:00      Change the way the camera follows player*
* Juju Moong      03/22/17  22:15      Modify followPathThree()                *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class CameraFollow2 : MonoBehaviour
{
   public float dampTime = 0.35f;
   public float maxPosX;
   public float minPosX;
   public int path;

   private Transform player;
   private Vector3 moveVelocity;
   private Vector3 desiredPosition;
   private float originalY;

   private void Start ()
   {
      player = GameObject.FindGameObjectWithTag ("Player").transform;
      originalY = transform.position.y;
   }

   private void FixedUpdate()
   {
      if (player != null)
      {
			if (!globalController.Instance.gameOver)
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
		if (player.GetComponent<PlayerControllerTest> ().facingRight)
		{
			pos.x += 5.0f; // Keeps camera slightly in front of player
		}
		//else
		//{
			//pos.x -= 5.0f; // Keeps camera slightly in front of player
		//}

      switch (path) 
      {
         case 1:
            pos.y = followPathOne ();
            break;
         case 2:
            pos.y = followPathTwo ();
            break;
         case 3:
            pos.y = followPathThree ();
            break;
         case 4:
            pos.y = followPathFour ();
            break;
      }

      pos.z = transform.position.z;

      desiredPosition = pos;
   }

   public void StopCamera()
   {
      FindPosition();

      desiredPosition.x = transform.position.x;

		/*if (player.position.x <= minPosX)
		{
			desiredPosition.x = minPosX + 5.0f;
			// Repositions the camera on a respawn and still keeping the camera slightly in front of the player
		}*/

      transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, 
                                              ref moveVelocity, dampTime);
   }

   // Beach and jungle first scene
   private float followPathOne ()
   {
      return 2.7f;
   }

   // Cave scene
   private float followPathTwo ()
   {
      float posY;

      if (player.position.x >= 203.0f &&
          player.position.x <= 215f &&
          player.position.y < 7.2f) 
      {
         posY = 5.0f;
      } 
      else if (player.position.x >= 184.0f &&
               player.position.x <= 203f &&
               player.position.y < 8.0f) 
      {
         posY = 4.0f;
      } 
      else if (player.position.x >= 135.0f &&
               player.position.x <= 166.0f &&
               player.position.y < 8.0f) 
      {
         posY = 5.0f;
      } 
      else if (player.position.x > 50.0f) 
      {
         posY = 14.0f;
      } 
      else if (player.position.y < -5.0f) 
      {
         posY = player.position.y;
      }
      else 
      {
         posY = 8.0f;
      }
      return posY;
   }

   // Resort scene
   private float followPathThree ()
   {
      float posY;

      if (player.position.x >= 17.0f && player.position.x < 116.0f) 
      {
         posY = 8.0f;
      } 
      else if (player.position.x <= -175.0f) 
      {
         posY = 7.75f;
      }
      else if (player.position.y >= 3.5f) 
      {
         posY = 14.0f;
      }
      else 
      {
         posY = 4.5f;
      }
      return posY;
   }

   // Final scene
   private float followPathFour ()
   {
      float posY;

      if (player.position.y >= 17f) 
      {
         posY = 22.0f;
      } 
      else if (player.position.y >= 12.0f) 
      {
         posY = 16.0f;
      }
      else if (player.position.x >= 25.5f && player.position.x <= 106.5f) 
      {
         posY = 11.0f;
      }
      else
      {
         posY = 5.5f;
      }
      return posY;
   }
}
