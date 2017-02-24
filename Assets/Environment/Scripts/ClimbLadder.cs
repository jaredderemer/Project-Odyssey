/********************************************************************** 
* Author            MM/DD/YY HH24:MM   Description                    * 
* Jonathan Rigsby   02/23/17 21:30     Script to climb ladder in      *
*									            decision hut                   * 
**********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
   public Transform CameraView;
   
   GameObject       player;
   playerController controller;
   
   void start ()
   {
      player = GameObject.Find("fishermanplain");
      controller = gameObject.GetComponent<playerController>(); // Nick...not sure why it doesnt work right either. went for a more direct approach
      
   }
   
   void LateUpdate ()
   {
      // Climb if the player is positioned in front of the ladder and pressing W
      if (transform.position.x > 6.2f && transform.position.x < 7.5f && Input.GetKey("q"))
      {
         // Make sure the character is rotated in the right direction
          if (gameObject.GetComponent<playerController>().facingRight) // NICK's  I change this and it works now..
         {
            transform.Rotate(0.0f, -90.0f, 0.0f);
         }
         else
         {
            transform.Rotate(0.0f, 90.0f, 0.0f);
         }
         
         while(transform.position.y < 4.6f)
         {
            transform.Translate(Vector3.up * 0.15f, Space.World);
            CameraView.Translate(Vector3.up * 0.15f, Space.World);
            Debug.Log("Climbing");
         }

         
      }



      else if (transform.position.x > 6.2f && transform.position.x < 7.5f)
      {
         // Display "W" key prompt
      }
   }
}